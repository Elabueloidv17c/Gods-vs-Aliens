using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class enemyKeepDist : enemyState
//{
    /*
     * ************************
     * * State where the enemy tries to maintain a set distance from the player that damaged it
     * ************************
     * */
    /*
    private Vector2 Dir;
    private Rigidbody2D rb;
    private GameObject m_target;
    private float timer;
    private float distance;
    private float threshold = 2;

    public void setTarget(GameObject _target)
    {
        m_target = _target;
    }

    public override void onEnter(enemyStateMchn _cntrl)
    {
        //Debug.Log("Enemy keeps distance");
        timer = 3.0f;
        distance = _cntrl.m_viewRadius;
    }

    public override void onUpdate(enemyStateMchn _cntrl)
    {
        
        keepDist(_cntrl.m_velocity);
        if(timer <= 0)
        {
            _cntrl.sChase.setTarget(m_target);
            _cntrl.setState(_cntrl.sChase);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
    }

    public override void onExit(enemyStateMchn _cntrl)
    {

    }

    public void keepDist(float _fScale)
    {

        Debug.Log(transform.position);
        Debug.Log(m_target.transform.position);
        float mag = (m_target.transform.position - GetComponent<Transform>().position).magnitude;

        if (mag <= (distance + threshold))
        {
            rb.AddForce(Flee(_fScale) * rb.mass);
            //Debug.Log("Enters Flee");
        }
        //else if (((target.transform.position - transform.position).magnitude - distanceFixer) >= (distance - threshold))
        else if (mag >= (distance - threshold))
        {
            rb.AddForce(Seek(_fScale) * rb.mass);
            //Debug.Log("Enters Seek");
        }
        else
        {
            //Debug.Log("Doing shit");
        }
        //Debug.Log((target.transform.position - transform.position).magnitude);
        rb.velocity *= 0.96f;
    }

    public Vector2 Seek(float _fScale)
    {
        Dir = m_target.transform.position - transform.position;
        Dir.y = 0;
        return Dir.normalized * _fScale;
    }

    public Vector2 Flee(float _fScale)
    {
        Dir = transform.position - m_target.transform.position;
        Dir.y = 0;
        return Dir.normalized * _fScale;
    }

    public float MAG(Vector2 vec)
    {
        return Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y);
    }
    */
//}
