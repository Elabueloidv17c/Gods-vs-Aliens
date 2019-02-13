using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class enemyPatrol : enemyState
{
    private float wanderTime = 2;
    private float navTimer = 0;
    private bool goingRight = false;

    public override void onEnter(enemyStateMchn _cntrl)
    {
        //Debug.Log("Enemy patrols");
        //_cntrl.animtr.
    }

    public override void onUpdate(enemyStateMchn _cntrl)
    {
       // Debug.Log("doing the patrol update");
        //Debug.Log(_cntrl.plyrList.Length);
        for (int i = 0; i < _cntrl.plyrList.Length; ++i)
        {
            //Debug.Log("Searching player list");
            if((_cntrl.transform.position - _cntrl.plyrList[i].transform.position).magnitude <= _cntrl.m_viewRadius)
            {
                _cntrl.sChase.setTarget(_cntrl.plyrList[i]);
                _cntrl.setState(_cntrl.sChase);
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

    public override void onExit(enemyStateMchn _cntrl)
    {
        // unload animation / graphics
    }
}