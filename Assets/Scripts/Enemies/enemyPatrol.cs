using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class enemyPatrol : enemyState
{
    //private float wanderTime = 2;
    //private float navTimer = 0;
    //private bool goingRight = false;

    public override void onEnter()
    {
        //Debug.Log("Enemy patrols");
        //_cntrl.animtr.
    }

    public override void onUpdate()
    {
       // Debug.Log("doing the patrol update");
        //Debug.Log(_cntrl.plyrList.Length);
        for (int i = 0; i < ESM.plyrList.Length; ++i)
        {
            //Debug.Log("Searching player list");
            if((ESM.transform.position - ESM.plyrList[i].transform.position).magnitude <= ESM.m_stats.m_viewRadius)
            {
                ESM.sChase.setTarget(ESM.plyrList[i]);
                ESM.setState(ESM.sChase);
            }

        }
        //if (navTimer <= wanderTime)
        //{
        //    if (goingRight)
        //    {
        //        _cntrl.rb.velocity = -Vector3.right * _cntrl.m_velocity;
        //    }
        //    else
        //    {
        //        _cntrl.rb.velocity = Vector3.right * _cntrl.m_velocity;
        //    }
        //    goingRight = !goingRight;
        //}
        //navTimer += Time.deltaTime;
    }

    public override void onExit()
    {
        // unload animation / graphics
    }
}