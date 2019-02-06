using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodIdleState : GodState
{
    public override void onEnter()
    {

    }
    public override void onExit()
    {

    }
    public override void onUpdate()
    {
        if (Input.GetKeyDown(GSM.PSInput.kRight) || Input.GetKeyDown(GSM.PSInput.kLeft))
        {
            GSM.setState(GSM.Walk);
        }
        else if (Input.GetKeyDown(GSM.PSInput.kDown))
        {
            GSM.setState(GSM.Crouch);
        }
        else if (Input.GetKeyDown(GSM.PSInput.kJump))
        {
            GSM.setState(GSM.Jump);
        }
        else if (Input.GetKeyDown(GSM.PSInput.kDash))
        {
            GSM.setState(GSM.Dash);
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
    }
}
