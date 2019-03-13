using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStateMchn : MonoBehaviour {
    /**
     * ************************
     * * Basic state machine for an enemy
     * ************************
     * */

    protected Stack<enemyState> stkEnemyState; // The stack for the state machine
    public enemyState CurrentState;
    public Rigidbody2D rb;
    public Animator animtr;
    public SpriteRenderer sr; // Sprite renderer flipX = false = facing left

    public enemyStats m_stats;

    public enemyPatrol sPatrol;
    public enemyChase sChase;
    public enemyAttack sAttack;
    //public enemyKeepDist sKeepDist;
    public GameObject[] plyrList; // The list of players gets fetched for behaviours

    public void pushState(enemyState newState)
    {
        stkEnemyState.Push(newState);
        stkEnemyState.Peek().onEnter();
        CurrentState = stkEnemyState.Peek();
    }

    public void setState(enemyState newState)
    {
        stkEnemyState.Peek().onExit();
        stkEnemyState.Pop();
        stkEnemyState.Push(newState);
        stkEnemyState.Peek().onEnter();
        CurrentState = stkEnemyState.Peek();
    }

    public void popState()
    {
        stkEnemyState.Peek().onExit();
        stkEnemyState.Pop();
        CurrentState = stkEnemyState.Peek();
    }

    public void getHit(atkStats _hit)
    {
        m_stats.m_hp -= _hit.m_damage;
        stkEnemyState.Peek().SendMessage("getHit", _hit, SendMessageOptions.DontRequireReceiver);
    }
}
