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
        stkEnemyState = new Stack<enemyState>();
        sPatrol = gameObject.AddComponent(typeof(enemyPatrol)) as enemyPatrol;
        sChase = gameObject.AddComponent(typeof(enemyChase)) as enemyChase;
        sAttack = gameObject.AddComponent(typeof(enemyAttack)) as enemyAttack;
        sKeepDist = gameObject.AddComponent(typeof(enemyKeepDist)) as enemyKeepDist;

        animtr = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        plyrList = Camera.main.GetComponent<playerList>().getPlayerArr();
        sr = GetComponent<SpriteRenderer>();
        pushState(sPatrol);
        m_stats = GetComponent<enemyStats>();

        m_stats.m_attackPower = 10;
        m_stats.m_hp = 100;
        m_stats.m_weight = 10;
    }



    // Update is called once per frame
    void Update()
    {
        //stkEnemyState.Peek().onUpdate();
    }
}
