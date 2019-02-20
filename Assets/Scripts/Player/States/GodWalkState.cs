using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodWalkState : GodState
{
    private float runFrameWindow;
    private float walkDir;

    public override void onEnter()
    {
        runFrameWindow = 0.4f;
    }

    public override void onExit()
    {
        runFrameWindow = 0.4f;
    }

    public override void onUpdate()
    {
        //--------------------------------------------------------------------------------------------------------------------
        //Logic
        //--------------------------------------------------------------------------------------------------------------------
        runFrameWindow -= Time.deltaTime;

        if (Input.GetKey(GSM.PSInput.kRight) || Input.GetKey(GSM.PSInput.kLeft))
        {
            walkDir = Input.GetAxis("Horizontal");
            GSM.rb.velocity = new Vector2(walkDir * GSM.PSInput.m_fwalkSpeed, GSM.rb.velocity.y);
        }

        //--------------------------------------------------------------------------------------------------------------------
        //Transitions
        //--------------------------------------------------------------------------------------------------------------------

        //Run
        if (runFrameWindow > 0 && (walkDir < 0 && Input.GetKeyDown(GSM.PSInput.kLeft)) || (walkDir > 0 && Input.GetKeyDown(GSM.PSInput.kRight)))
        {
            GSM.setState(GSM.Run);
        }

        //Jump
        else if (Input.GetKeyDown(GSM.PSInput.kJump))
        {
            GSM.setState(GSM.Jump);
        }

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
        else if (runFrameWindow <= 0)
        {
            GSM.setState(GSM.Idle);
        }
    }
}
