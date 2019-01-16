using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SpriteRenderer))]
//[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    //public playerInput m_input;
    //public playerStats m_stats;
    //public playerFSM m_stateMachine;

    SpriteRenderer m_sprite;
    BoxCollider2D m_collider;
    BoxCollider2D mp_actualLayer;
    Rigidbody2D m_rigidBody;
    Animator m_animator;
    BoxCollider2D m_actualLayer;
    public bool m_isGrounded;
    public bool m_isCrouching;
    public bool m_isDashing;
    public bool m_isRunning;
    float m_crouch;
    float m_walk;
    float m_run;
    float m_speed;
    float m_direction;
    float m_jumpForce;
    float m_tapSpeed;
    float m_lastPush;
    private float m_currentDashTime;
    private bool m_dashRunning;
    private bool m_lookingLeft;
    public float m_maxDashTime;
    public float m_dashSpeed;
    public float m_dashStoppingSpeed;
    public int m_currentLayer;
    public LayerMask m_whatIsEnemies;//para detectar que es el enemigo
    public Transform m_attackPos;//para posicion
    public float m_attackRange;//rango de ataque
    public int m_damage;//el daño es modificado desde el motor
    public bool m_isAttack;

    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
        //m_stateMachine.setInput(m_input); // Tells the state machine what its inputs are

       
        m_collider = GetComponent<BoxCollider2D>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_isGrounded = true;
        m_isCrouching = false;
        m_isDashing = false;
        m_isRunning = false;
        m_isAttack = false;
        m_dashRunning = false;
        m_lookingLeft = false;
        m_maxDashTime = 0.25f;
        m_dashSpeed = 1000.0f;
        m_jumpForce = 220;
        m_direction = 0;
        m_speed = 2;
        m_crouch = 1.0f;
        m_walk = 2;
        m_run = 6;
        m_tapSpeed = 0.20f;
        m_lastPush = m_tapSpeed;
        m_currentDashTime = m_maxDashTime;
        
    }

    void Update()
    {
        //m_stateMachine.onUpdate();
        Movement();
    }

    void Walk()
    {
        //Si el personaje está saltando no puede moverse
        if (m_isGrounded)
        {
            //Tomo el input del usuario y lo convierto en mi vector de direccion
            m_direction = Input.GetAxis("Horizontal");
            //Muevo al personaje a la dirección que capturó la variable "m_direcion"
            m_rigidBody.velocity = new Vector2(m_direction * m_speed, m_rigidBody.velocity.y);
        }
        if (m_direction != 0 && m_isGrounded)
        {
            //Cambio la dirección a la que el sprite está apuntando dependiendo de hacia dónde se mueve el jugador
            m_sprite.flipX = m_direction < 0;
        }
    }

    void Run()
    {
        //Esta variable me indica hace cuánto tiempo el jugador presionó una tecla de movimiento, suma en cada frame
        m_lastPush += Time.deltaTime;
        //Si el jugador presiona por segunda vez cualquier tecla de direccion
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Y la última vez que la presionó es menor al limite de tapSpeed
            if (m_lastPush < m_tapSpeed)
            {
                //Cambio la velocidad de movimiento a correr
                m_speed = m_run;
                m_isRunning = true;
            }
            m_lastPush = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_speed = m_walk;
            m_isRunning = false;
        }
    }

    void Jump()
    {
        //Si el jugador se encuentra en el suelo y presiona el boton de salto
        if (Input.GetKeyDown(KeyCode.Space) && m_isGrounded)
        {
            //Si el personaje no está agachado
            if (!m_isCrouching)
            {
                //Añado fuerza en el eje "y" para que se eleve
                m_rigidBody.AddForce(new Vector2(0, m_jumpForce));
            }
            else
            {
                //Si está agachado le aplico un incremento de elevacion de 20%
                m_rigidBody.AddForce(new Vector2(0, m_jumpForce * 1.2f));
            }
            m_isGrounded = false;
        }
    }

    void ChangeLayer()
    {
        //LayerUp
        if (Input.GetKeyUp(KeyCode.LeftControl) && m_isGrounded)
        {
            if (gameObject.layer == 14 || gameObject.layer == 13)
            {
                m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, 1.0f);
                gameObject.layer = gameObject.layer - 1;
            }
        }
        //LayyerDown
        if (Input.GetKeyUp(KeyCode.LeftShift) && m_isGrounded)
        {
            if (gameObject.layer == 12 || gameObject.layer == 13)
            {
                m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, 3.0f);
                gameObject.layer = gameObject.layer + 1;
            }
        }
    }

    void Attack()
    {
        if (m_isAttack)
        {
            m_isAttack = false;
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (!m_isAttack)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    Collider2D[] enemieToDamage = Physics2D.OverlapCircleAll(m_attackPos.position, m_attackRange, m_whatIsEnemies);//calculoa los enemigos a atacar
                    for (int i = 0; i < enemieToDamage.Length; i++)//golpea a cada enemigo
                    {
                        //enemieToDamage[i].GetComponent<Transform>().TakeDamage(m_damage);//esto es para golpear a los enemigos
                    }
                }
              //  m_timeBtwAttack = m_startTimeBtwAttack;
            }
            //else
            //{
            //    m_timeBtwAttack -= Time.deltaTime;
            //}
           // m_attackTime += Time.deltaTime;
            m_isAttack = true;
        }
    }

    void Animation()
    {
        //Ligo el miembro a las variables que se encargan de interpretar qué acción está haciendo el personaje
        m_animator.SetBool("isRunning", m_speed > 2 || m_speed < -2);
        m_animator.SetBool("isWalking", m_direction != 0);
        m_animator.SetBool("isGrounded", m_isGrounded);
        m_animator.SetBool("isCrouching", m_isCrouching);
        m_animator.SetBool("isAttack", m_isAttack);
        //De esta forma el animador se encarga de cambiar la animación cuando se necesario
    }

    void Movement()
    {
        if (m_direction > 0.0f)
        {
            m_lookingLeft = false;
        }
        else if (m_direction < 0.0f)
        {
            m_lookingLeft = true;
        }

        Walk();
        Run();
        Jump();
        Crouch();
        Dash();
        Attack();
        ChangeLayer();
        Animation();
    }

    void Crouch()
    {
        //Si el jugador presiona la flecha hacia abajo mientras está en el suelo (y no esté ya agachado)
        if (Input.GetKeyDown(KeyCode.DownArrow) && m_isGrounded && !m_isCrouching)
        {
            //Cambio su velocidad de movimiento y su estado a agachado para asegurarme de que 
            //en el siguiente frame no entre a este segmento de código
            m_speed = m_crouch;
            m_isCrouching = true;
            //Aqui cambio el tamaño y la posicion del collider para que coincida con el sprite
            m_collider.size = new Vector2(m_collider.size.x, m_collider.size.y / 2);
            m_collider.offset = new Vector2(m_collider.offset.x, m_collider.offset.y - m_collider.size.y / 2);
        }
        //Si el jugador suelta la flecha abajo o salta
        if ((Input.GetKeyUp(KeyCode.DownArrow) && m_isCrouching) || (!m_isGrounded && m_isCrouching))
        {
            //Cambio la velocidad de movimiento y su estado a no agachado
            m_speed = m_walk;
            m_isCrouching = false;
            //Aqui cambio el tamaño y la posicion del collider para que coincida con el sprite
            m_collider.offset = new Vector2(m_collider.offset.x, m_collider.offset.y + m_collider.size.y / 2);
            m_collider.size = new Vector2(m_collider.size.x, m_collider.size.y * 2);
        }
    }

    void Dash()
    {
        //Este movimiento solo estará disponible si el jugador está agachado
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !m_isDashing && !m_isAttack)
        {
            if (m_isRunning)
            {
                m_collider.size = new Vector2(m_collider.size.x, m_collider.size.y / 2);
                m_collider.offset = new Vector2(m_collider.offset.x, m_collider.offset.y - m_collider.size.y / 2);
                m_direction = Input.GetAxis("Horizontal");
                m_currentDashTime = 0.0f;
                m_isDashing = true;
                m_dashRunning = true;
            }
            else if (m_isCrouching)
            {
                m_direction = Input.GetAxis("Horizontal");
                m_currentDashTime = 0.0f;
                m_isDashing = true;
            }
        }
        if (m_currentDashTime < m_maxDashTime && m_isDashing)
        {
            if (m_rigidBody.velocity.x == 0)
            {
                if (m_lookingLeft)
                {
                    m_rigidBody.velocity = new Vector2(-m_dashSpeed * Time.deltaTime, 0);
                }
                else
                {
                    m_rigidBody.velocity = new Vector2(m_dashSpeed * Time.deltaTime, 0);
                }
            }
            else
            {
                m_rigidBody.velocity = new Vector2(m_direction * m_dashSpeed * Time.deltaTime, 0);
            }
            m_currentDashTime += Time.deltaTime;
        }
        if (m_currentDashTime >= m_maxDashTime && m_isDashing)
        {
            if (m_dashRunning)
            {
                m_rigidBody.velocity = new Vector2(0, 0);
                m_collider.offset = new Vector2(m_collider.offset.x, m_collider.offset.y + m_collider.size.y / 2);
                m_collider.size = new Vector2(m_collider.size.x, m_collider.size.y * 2);
                m_isDashing = false;
                m_dashRunning = false;
            }
            else
            {
                m_rigidBody.velocity = new Vector2(0, 0);
                m_isDashing = false;
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Me encargo de revisar en qué momento el jugador se despega del suelo para que no pueda saltar en el aire
        m_isGrounded = mp_actualLayer.IsTouching(m_collider);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "PlayArea")
        {
            //mp_actualLayer = collision.otherCollider.GetComponent<BoxCollider2D>();
            //gameObject.layer = mp_actualLayer.GetComponent<GameObject>().layer;
            m_isGrounded = true;
        }
        
    }
}