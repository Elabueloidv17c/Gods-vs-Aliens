using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodRunState : GodState
{
    private float runFrameWindow;
    private bool gotInput;

    public override void onEnter()
    {
        GSM.m_animator.SetBool("isRunning", true);
        runFrameWindow = 0.0f;
        gotInput = false;
    }

    public override void onExit()
    {
        GSM.m_animator.SetBool("isRunning", false);
        GSM.PSInput.m_lastState = LastState.Run;
        GSM.PSInput.m_currentDashCooldown = 0.0f;
        runFrameWindow = 0.0f;
        gotInput = false;
    }

    public override void onUpdate()
    {
        //--------------------------------------------------------------------------------------------------------------------
        //Logic
        //--------------------------------------------------------------------------------------------------------------------
        GSM.PSInput.m_currentDashCooldown += Time.deltaTime;
        gotInput = false;

        if (Input.GetKey(GSM.PSInput.kRight) || Input.GetKey(GSM.PSInput.kLeft))
        {
            GSM.rb.velocity = new Vector2(Input.GetAxis("Horizontal") * GSM.PSInput.m_frunSpeed, GSM.rb.velocity.y);
            gotInput = true;
        }

        else
        {
            runFrameWindow += Time.deltaTime;
        }

        //--------------------------------------------------------------------------------------------------------------------
        //Transitions
        //--------------------------------------------------------------------------------------------------------------------
        
        //Idle
        if (!gotInput && runFrameWindow > 0.1f)
        {
            GSM.setState(GSM.Idle);
        }

        //Jump
        else if (Input.GetKeyDown(GSM.PSInput.kJump))
        {
            GSM.setState(GSM.Jump);
        }

        //Dash
        else if ((Input.GetKeyDown(GSM.PSInput.kDash) || Input.GetKeyDown(GSM.PSInput.kDown)) 
                 && (GSM.PSInput.m_currentDashCooldown >= GSM.PSInput.m_fdashCoolDown))
        {
            GSM.setState(GSM.Dash);
        }

        //Change Layer
        else if (Input.GetKeyDown(GSM.PSInput.kChangeLayerDown) || Input.GetKeyDown(GSM.PSInput.kChangeLayerUp))
        {
            GSM.setState(GSM.ChangeLayer);

            if (Input.GetKeyDown(GSM.PSInput.kChangeLayerDown))
            {
                GSM.ChangeLayer.setLayerDir(false);
            }

            else
            {
                GSM.ChangeLayer.setLayerDir(true);
            }
        }
    }
}
