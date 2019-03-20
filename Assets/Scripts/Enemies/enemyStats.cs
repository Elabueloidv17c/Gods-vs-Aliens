using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour {
    /**
     * ************************
     * * Script attached to enemy actors that contains all relevant combat & mobility stats
     * ************************
     * */
    public float m_hp;
    public float m_weight;
    public float m_attackPower;
    public float m_attackDuration;
    public float m_attackDist;
    public float m_viewRadius;
    public float m_velocity;
    public float m_shotVelocity;
    public float m_shotCoolDown;
    public float m_approachThreshold;
}
