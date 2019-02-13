using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStateMchn : MonoBehaviour {
    /**
     * ************************
     * * Basic state machine for an enemy
     * ************************
     * */

    private Stack<enemyState> stkEnemyState; // The stack for the state machine
    public Rigidbody2D rb;
    public Animator animtr;
    public SpriteRenderer sr; // Sprite renderer flipX = false = facing left

    public enemyStats m_stats;

    public enemyPatrol sPatrol;
    public enemyChase sChase;
    public enemyAttack sAttack;
    public enemyKeepDist sKeepDist;
    public GameObject[] plyrList; // The list of players gets fetched for behaviours

    public GameObject m_hitBox; // GameObject to be instantiated to be the attack
    public float m_shotSpeed;
    public float m_attackTimer; // frequency in seconds for enemy attack
    public float m_velocity; // velocity modifier to be applied to rigidbody
    public float m_attackDist; // min distance for enemy attack 
    public float m_attackDuration; // attack duration in seconds
    public float m_viewRadius; // radius of enemy awareness


    void Start()
    {
        stkEnemyState = new Stack<enemyState>();
        sPatrol = new enemyPatrol();
        sChase = new enemyChase();
        sAttack = new enemyAttack();
        sKeepDist = new enemyKeepDist();
        animtr = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        plyrList = Camera.main.GetComponent<playerList>().getPlayerArr();
        sr = GetComponent<SpriteRenderer>();
        pushState(sPatrol);
        m_stats = new enemyStats();
        m_stats.m_attackPower = 10;
        m_stats.m_hp = 100;
        m_stats.m_weight = 10;
    }



    /**
     * ************************
     * * Methods to control the state stack
     * * (this) is passed as param so the states know who their state machine is 
     * ************************
     * */
    public void pushState(enemyState newState)
    {
        stkEnemyState.Push(newState);
        stkEnemyState.Peek().onEnter(this);
    }

    public void setState(enemyState newState)
    {
        stkEnemyState.Peek().onExit(this);
        stkEnemyState.Pop();
        stkEnemyState.Push(newState);
        stkEnemyState.Peek().onEnter(this);
    }

    public void popState()
    {
        stkEnemyState.Peek().onExit(this);
        stkEnemyState.Pop();
    }

    public void Update()
    {
        stkEnemyState.Peek().onUpdate(this);
        manageSprite();
        manageStats();
        //Debug.Log("doing the update");
    }
    
    public void getHit(atkStats _hit)
    {
        m_stats.m_hp -= _hit.m_damage;
        stkEnemyState.Peek().SendMessage("getHit", _hit, SendMessageOptions.DontRequireReceiver);
    }

    public void manageStats()
    {
        if (m_stats.m_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void manageSprite()
    {
        if (rb.velocity.x < 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
        //animtr.SetBool("move", stkEnemyState.Peek() == sChase || stkEnemyState.Peek() == sPatrol || stkEnemyState.Peek() == sKeepDist);
    }
    //void OnDrawGizmos()
    //{
    //    if (eState != null )
    //    {
    //        Gizmos.color = eState.sceneGizmoColor;
    //        Gizmos.DrawWireSphere(tr.position, fRad);
    //    }
    //}
}
