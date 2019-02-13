using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : enemyState
{

    
    private float m_stateTimer;
    private GameObject target;
    public void setTarget(GameObject _target)
    {
        target = _target;
    }

    public override void onEnter(enemyStateMchn _cntrl)
    {
        //Debug.Log("Enemy attacks");
        m_stateTimer = _cntrl.m_attackDuration;
        GameObject clone = Instantiate(_cntrl.m_hitBox, _cntrl.transform);
        float cloneMass = clone.GetComponent<Rigidbody2D>().mass;
        clone.GetComponent<Transform>().localScale *= 0.5f;
        clone.GetComponent<Rigidbody2D>().AddForce((target.transform.position - _cntrl.transform.position).normalized * _cntrl.m_shotSpeed * cloneMass);
        if (_cntrl.sr.flipX)
        {
            clone.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public override void onUpdate(enemyStateMchn _cntrl)
    {
        if (m_stateTimer <= 0)
        {
            _cntrl.sChase.setTarget(target);
            _cntrl.setState(_cntrl.sChase);
        }
        else
        {
            m_stateTimer -= Time.deltaTime;
        }
        
    }

    public override void onExit(enemyStateMchn _cntrl)
    {
        _cntrl.animtr.SetBool("Move", true);
    }
}
