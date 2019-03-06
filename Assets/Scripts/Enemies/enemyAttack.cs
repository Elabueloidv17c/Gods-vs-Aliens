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

    public override void onEnter()
    {
        //Debug.Log("Enemy attacks");
        //m_stateTimer = ESM;
        //GameObject clone = Instantiate(ESM.m_hitBox, ESM.transform);
        //float cloneMass = clone.GetComponent<Rigidbody2D>().mass;
        //clone.GetComponent<Transform>().localScale *= 0.5f;
        //clone.GetComponent<Rigidbody2D>().AddForce((target.transform.position - ESM.transform.position).normalized * ESM.m_shotSpeed * cloneMass);
        if (ESM.sr.flipX)
        {
            //clone.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public override void onUpdate()
    {
        if (m_stateTimer <= 0)
        {
            ESM.sChase.setTarget(target);
            ESM.setState(ESM.sChase);
        }
        else
        {
            m_stateTimer -= Time.deltaTime;
        }
        
    }

    public override void onExit()
    {
        ESM.animtr.SetBool("Move", true);
    }
}
