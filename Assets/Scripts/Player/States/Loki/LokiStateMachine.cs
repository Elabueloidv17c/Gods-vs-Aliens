using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokiStateMachine : GodStateMachine
{
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        PSInput = GetComponent<PlayerInputStats>();
        godStack = new Stack<GodState>();

        Attack = gameObject.AddComponent(typeof(LokiStateATK)) as LokiStateATK;
        Attack.setFSM(this);
        Dash = gameObject.AddComponent(typeof(GodDashState)) as GodDashState;
        Dash.setFSM(this);
        ChangeLayer = gameObject.AddComponent(typeof(GodChangeLayerState)) as GodChangeLayerState;
        ChangeLayer.setFSM(this);
        Crouch = gameObject.AddComponent(typeof(GodCrouchState)) as GodCrouchState;
        Crouch.setFSM(this);
        CrouchWalk = gameObject.AddComponent(typeof(GodCrouchWalkState)) as GodCrouchWalkState;
        CrouchWalk.setFSM(this);
        Die = gameObject.AddComponent(typeof(GodDieState)) as GodDieState;
        Die.setFSM(this);
        Idle = gameObject.AddComponent(typeof(GodIdleState)) as GodIdleState;
        Idle.setFSM(this);
        Jump = gameObject.AddComponent(typeof(GodJumpState)) as GodJumpState;
        Jump.setFSM(this);
        Run = gameObject.AddComponent(typeof(GodRunState)) as GodRunState;
        Run.setFSM(this);
        Walk = gameObject.AddComponent(typeof(GodWalkState)) as GodWalkState;
        Walk.setFSM(this);

        pushState(Idle);
    }

    // Update is called once per frame
    void Update()
    {
        godStack.Peek().onUpdate();
        spriteFlip();
    }

    public override void GetHit(atkStats hit)
    {
        PSInput.m_currentHealth -= hit.m_damage;
        rb.AddForce(hit.m_atkDir * hit.m_knockbackForce);
    }
}
