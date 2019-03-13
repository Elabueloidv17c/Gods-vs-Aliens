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
        GameObject clone = Instantiate(ESM.GetComponent<LightShipFSM>().getShotHitBox(), ESM.transform);
        float cloneMass = clone.GetComponent<Rigidbody2D>().mass;
        //clone.GetComponent<Transform>().localScale *= 0.5f;
        Vector2 atkDir = (target.transform.position - ESM.transform.position).normalized;
        clone.GetComponent<Rigidbody2D>().AddForce(atkDir * ESM.m_stats.m_shotVelocity * cloneMass);
        clone.GetComponent<lightShipShot>().setDir(atkDir);
        if (ESM.sr.flipX)
        {
            clone.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public override void onUpdate()
    {
        if (m_stateTimer >= ESM.m_stats.m_attackDuration)
        {
            ESM.sChase.setTarget(target);
            ESM.setState(ESM.GetComponent<LightShipFSM>().getKeepDistState());
            ESM.GetComponent<LightShipFSM>().getKeepDistState().GetComponent<enemyKeepDist>().setTarget(target);
        }
        else
        {
            m_stateTimer += Time.deltaTime;
        }
        
    }

    public override void onExit()
    {
        m_stateTimer = 0;
        if (ESM.animtr)
        {
            ESM.animtr.SetBool("Move", true);
        }
    }
}
