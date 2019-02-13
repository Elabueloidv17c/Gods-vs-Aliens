using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodWalkState : GodState
{
    private bool gotInput;
    private float runFrameWindow;
    private float walkDir;

    public override void onEnter()
    {
        runFrameWindow = 0.4f;
        gotInput = false;
    }

    public override void onExit()
    {
        runFrameWindow = 0.4f;
        gotInput = false;
    }

    public override void onUpdate()
    {
        //--------------------------------------------------------------------------------------------------------------------
        //Logic
        //--------------------------------------------------------------------------------------------------------------------
        gotInput = false;
        GSM.rb.velocity *= GSM.PSInput.m_SpeedDampener;
        runFrameWindow -= Time.deltaTime;

        Debug.Log(runFrameWindow);

        if (Input.GetKey(GSM.PSInput.kRight) || Input.GetKey(GSM.PSInput.kLeft))
        {
            GSM.rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0) * GSM.PSInput.m_fwalkSpeed);
            gotInput = true;
            walkDir = Input.GetAxis("Horizontal");
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
        else if (!gotInput && runFrameWindow <= 0)
        {
            GSM.setState(GSM.Idle);
        }
    }
}
