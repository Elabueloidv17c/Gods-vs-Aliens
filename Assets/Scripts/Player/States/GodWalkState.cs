using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodWalkState : GodState
{
    private float runFrameWindow;
    private float walkDir;
    private bool gotInput;

    public override void onEnter()
    {
        GSM.m_animator.SetBool("isWalking", true);
        runFrameWindow = 0.4f;
        gotInput = false;
    }

    public override void onExit()
    {
        GSM.m_animator.SetBool("isWalking", false);
        GSM.PSInput.m_lastState = LastState.Walk;
        runFrameWindow = 0.4f;
        GSM.PSInput.m_currentDashCooldown = 0.0f;
        gotInput = false;
    }

    public override void onUpdate()
    {
        //--------------------------------------------------------------------------------------------------------------------
        //Logic
        //--------------------------------------------------------------------------------------------------------------------
        runFrameWindow -= Time.deltaTime;
        GSM.PSInput.m_currentDashCooldown += Time.deltaTime;
        gotInput = false;


        if (Input.GetKey(GSM.PSInput.kRight) || Input.GetKey(GSM.PSInput.kLeft))
        {
            walkDir = Input.GetAxis("Horizontal");
            GSM.rb.velocity = new Vector2(walkDir * GSM.PSInput.m_fwalkSpeed, GSM.rb.velocity.y);

            gotInput = true;
        }

        //--------------------------------------------------------------------------------------------------------------------
        //Transitions
        //--------------------------------------------------------------------------------------------------------------------
        //Attack
        if (Input.GetKeyDown(GSM.PSInput.kATK))
        {
            GSM.setState(GSM.Attack);
        }

        //Run
        else if (runFrameWindow > 0 && (walkDir < 0 && Input.GetKeyDown(GSM.PSInput.kLeft)) || (walkDir > 0 && Input.GetKeyDown(GSM.PSInput.kRight)))
        {
            GSM.setState(GSM.Run);
        }

        //Dash
        else if (Input.GetKey(GSM.PSInput.kDash) && (GSM.PSInput.m_currentDashCooldown >= GSM.PSInput.m_fdashCoolDown))
        {
            GSM.setState(GSM.Dash);
        }

        //Jump
        else if (Input.GetKeyDown(GSM.PSInput.kJump))
        {
            GSM.setState(GSM.Jump);
        }

        //Crouch
        //Crouch
        else if (Input.GetKeyDown(GSM.PSInput.kDown))
        {
            GSM.setState(GSM.CrouchWalk);
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

        //Idle
        else if (!gotInput && runFrameWindow <= 0)
        {
            GSM.setState(GSM.Idle);
        }
    }
}
