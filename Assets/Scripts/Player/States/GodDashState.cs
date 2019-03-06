using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodDashState : GodState
{
    float currentDashTime;
    float direction;


    public override void onEnter()
    {
        GSM.m_animator.SetBool("isDashing", true);

        if(GSM.rb.velocity.x > 0.0f)
        {
            direction = 1.0f;
        }

        else
        {
            direction = -1.0f;
        }

        currentDashTime = 0.0f;
        GSM.rb.velocity = new Vector2(direction * GSM.PSInput.m_fdashSpeed, 0.0f);
    }

    public override void onExit()
    {
        GSM.m_animator.SetBool("isDashing", false);

        currentDashTime = 0.0f;
        direction = 0.0f;
    }

    public override void onUpdate()
    {
        if (currentDashTime >= GSM.PSInput.m_fdashTime)
        {
            if (GSM.PSInput.m_lastState == LastState.Idle)
            {
                GSM.rb.velocity = new Vector2(0.0f, 0.0f);
                GSM.setState(GSM.Idle);
            }

            if (GSM.PSInput.m_lastState == LastState.Walk)
            {
                GSM.rb.velocity = new Vector2(direction * GSM.PSInput.m_fwalkSpeed, 0.0f);
                GSM.setState(GSM.Walk);
            }

            if (GSM.PSInput.m_lastState == LastState.Run)
            {
                GSM.rb.velocity = new Vector2(direction * GSM.PSInput.m_frunSpeed, 0.0f);
                GSM.setState(GSM.Run);
            }
        }

        currentDashTime += Time.deltaTime;
    }
}