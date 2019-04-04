using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GodStateMachine : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator m_animator;
    public BoxCollider2D m_collider;

    public Stack<GodState> godStack;
    public PlayerInputStats PSInput;

    public GodChangeLayerState ChangeLayer;
    public GodCrouchState Crouch;
    public GodCrouchWalkState CrouchWalk;
    public GodDieState Die;
    public GodDashState Dash;
    public GodIdleState Idle;
    public GodJumpState Jump;
    public GodRunState Run;
    public GodWalkState Walk;
    public GodState Attack;

    public GodState currState;


    public void setState(GodState newState)
    {
        godStack.Peek().onExit();
        godStack.Pop();
        godStack.Push(newState);
        currState = newState;
        godStack.Peek().onEnter();
    }

    public void pushState(GodState newState)
    {
        godStack.Push(newState);
        currState = newState;
        godStack.Peek().onEnter();
    }

    public void popState()
    {
        godStack.Peek().onExit();
        godStack.Pop();
    }

    public void spriteFlip()
    {
        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
    }

    public abstract void GetHit(atkStats hit);
}
