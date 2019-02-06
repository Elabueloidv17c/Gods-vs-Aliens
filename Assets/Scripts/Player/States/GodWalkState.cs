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
        gotInput = false;
        if (Input.GetKey(GSM.PSInput.kRight) || Input.GetKey(GSM.PSInput.kLeft))
        {
            GSM.rb.AddForce(new Vector3(Input.GetAxis("Horizontal") , 0) * GSM.PSInput.m_fwalkSpeed);
            gotInput = true;
            walkDir = Input.GetAxis("Horizontal");
        }
        else if (Input.GetKeyDown(GSM.PSInput.kRight) || Input.GetKeyDown(GSM.PSInput.kLeft))
        {
            if((walkDir < 0 && Input.GetKeyDown(GSM.PSInput.kLeft)) || (walkDir > 0 && Input.GetKeyDown(GSM.PSInput.kRight)))
            {
                GSM.setState(GSM.Run);
            }
        }
        else if (Input.GetKeyDown(GSM.PSInput.kJump))
        {
            GSM.setState(GSM.Jump);
        }
        else if (Input.GetKeyDown(GSM.PSInput.kDown))
        {
            GSM.setState(GSM.CrouchWalk);
        }
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
        else if (!gotInput && runFrameWindow <= 0.0f)
        {
            GSM.setState(GSM.Idle);
        }
        //float y = GSM.rb.velocity.y;

        GSM.rb.velocity *= GSM.PSInput.m_SpeedDampener;
        runFrameWindow -= Time.deltaTime;
    }
}
