using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loki_hitBox_0 : MonoBehaviour
{
    // TODO: make base class hitbox
    public float liveTimer;
    enemyStateMchn enemy;
    atkStats m_atkStats;

    public void Start()
    {
        m_atkStats = GetComponent<atkStats>();
    }

    private void Update()
    {
        if (liveTimer <= 0)
        {
            Destroy(gameObject);
        }
        liveTimer -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        coll.otherCollider.SendMessage("playerGetHit", SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        coll.SendMessage("playerGetHit", SendMessageOptions.DontRequireReceiver);
        if (coll.gameObject.tag == "Enemy")
        {
            enemy = coll.gameObject.GetComponent<enemyStateMchn>();
            if (enemy)
            {
                enemy.GetHit(m_atkStats);
            }
            Destroy(gameObject);
        }
    }
    public void setDir(Vector2 dir)
    {
        if (m_atkStats)
        {
            m_atkStats.m_atkDir = dir;
        }
    }
}
