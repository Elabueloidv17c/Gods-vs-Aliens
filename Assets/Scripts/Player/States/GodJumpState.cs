﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodJumpState : GodState
{
    public override void onEnter()
    {
        GSM.m_animator.SetBool("isJumping", true);
        GSM.rb.velocity = new Vector2(GSM.rb.velocity.x, GSM.PSInput.m_fjumpForce);
    }

    public override void onExit()
    {
        GSM.m_animator.SetBool("isJumping", false);
        GSM.PSInput.m_lastState = LastState.Jump;
    }

    public override void onUpdate()
    {
        //Attack
        if (Input.GetKeyDown(GSM.PSInput.kATK))
        {
            GSM.setState(GSM.Attack);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (GSM.PSInput.m_lastState == LastState.Idle)
            {
                GSM.setState(GSM.Idle);
            }

            if (GSM.PSInput.m_lastState == LastState.Walk)
            {
                GSM.setState(GSM.Walk);
            }

            if (GSM.PSInput.m_lastState == LastState.Run)
            {
                GSM.setState(GSM.Run);
            }
        }
    }
}
