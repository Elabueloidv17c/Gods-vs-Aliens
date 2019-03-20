using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShipFSM : enemyStateMchn
{
    public GameObject m_hitBox; // GameObject to be instantiated to be the attack
    public float m_shotSpeed;
    public float m_attackTimer; // frequency in seconds for enemy attack
    public float m_velocity; // velocity modifier to be applied to rigidbody
    public float m_attackDist; // min distance for enemy attack 
    public float m_attackDuration; // attack duration in seconds
    public float m_viewRadius; // radius of enemy awareness

    public enemyState sKeepDist;

    void Start()
    {
        plyrList = Camera.main.GetComponent<playerList>().getPlayerArr();
        stkEnemyState = new Stack<enemyState>();
        sPatrol = gameObject.AddComponent(typeof(enemyPatrol)) as enemyPatrol;
        sChase = gameObject.AddComponent(typeof(enemyChase)) as enemyChase;
        sAttack = gameObject.AddComponent(typeof(enemyAttack)) as enemyAttack;
        sKeepDist = gameObject.AddComponent(typeof(enemyKeepDist)) as enemyKeepDist;

        sPatrol.setFSM(this);
        sChase.setFSM(this);
        sAttack.setFSM(this);
        sKeepDist.setFSM(this);

        animtr = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //plyrList = Camera.main.GetComponent<playerList>().getPlayerArr();
        sr = GetComponent<SpriteRenderer>();
        pushState(sPatrol);
        m_stats = GetComponent<enemyStats>();
    }



    // Update is called once per frame
    void Update()
    {
        stkEnemyState.Peek().onUpdate();
        CurrentState = stkEnemyState.Peek();
    }

    public GameObject getShotHitBox()
    {
        return m_hitBox;
    }

    public enemyState getKeepDistState()
    {
        return sKeepDist;
    }
}
