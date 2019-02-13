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

    public override void onEnter(enemyStateMchn _cntrl)
    {
        //Debug.Log("Enemy chases");
        rb = _cntrl.rb;
    }

    public override void onUpdate(enemyStateMchn _cntrl)
    {
        // Temporary seek implementation
        if ((m_target.transform.position - _cntrl.transform.position).magnitude < _cntrl.m_attackDist)
        {
            _cntrl.sAttack.setTarget(m_target);
            _cntrl.pushState(_cntrl.sAttack);
        }
        else
        {
            Vector2 v = m_target.transform.position - _cntrl.transform.position;
            v.y = 0;
            rb.AddForce(v.normalized * _cntrl.m_velocity);
        }
        _cntrl.rb.velocity *= 0.94f;
    }

    public override void onExit(enemyStateMchn _cntrl)
    {
        m_target = null;
    }

    //void getHit()
    //{
    //    _cntrl.pushState(_cntrl.sKeepDist);
    //}
}
