using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightShipShot : MonoBehaviour {
    // TODO: make base class hitbox
    public float liveTimer;
    GodStateMachine player;
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
        if(coll.gameObject.tag == "Player")
        {
            player = coll.gameObject.GetComponent<GodStateMachine>();
            if (player)
            {
                player.GetHit(m_atkStats);
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
