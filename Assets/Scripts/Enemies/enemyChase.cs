using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChase : enemyState
{
    /**
     * ************************
     * * This state becomes active when this enemy gets close enough to any player
     * * m_target gets set when putting the state on the stack
     * ************************
     * */
    private Vector2 steerVec;
    private Rigidbody2D rb;

    private GameObject m_target;

    public void setTarget(GameObject t)
    {
        m_target = t;
    }

    public override void onEnter()
    {
        //Debug.Log("Enemy chases");
        rb = ESM.rb;
    }

    public override void onUpdate()
    {
        // Temporary seek implementation
        if ((m_target.transform.position - ESM.transform.position).magnitude < 5 /*ESM.m_attackDist*/)
        {
            ESM.sAttack.setTarget(m_target);
            ESM.pushState(ESM.sAttack);
        }
        else
        {
            Vector2 v = m_target.transform.position - ESM.transform.position;
            v.y = 0;
            rb.AddForce(v.normalized * ESM.m_stats.m_velocity);
        }
        ESM.rb.velocity *= 0.94f;
    }

    public override void onExit()
    {
        m_target = null;
    }

    //void getHit()
    //{
    //    _cntrl.pushState(_cntrl.sKeepDist);
    //}
}
