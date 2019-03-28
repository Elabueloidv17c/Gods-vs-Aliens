using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodIdleState : GodState
{
    public override void onEnter()
    {
        GSM.rb.velocity = new Vector2(0.0f, 0.0f);
    }

    public override void onExit()
    {
        GSM.PSInput.m_lastState = LastState.Idle;
    }

    public override void onUpdate()
    { 
        //--------------------------------------------------------------------------------------------------------------------
        //Transitions
        //--------------------------------------------------------------------------------------------------------------------

        //Walk
        if (Input.GetKey(GSM.PSInput.kRight) || Input.GetKey(GSM.PSInput.kLeft))
        {
            GSM.setState(GSM.Walk);
        }

        //Crouch
        else if (Input.GetKeyDown(GSM.PSInput.kDown))
        {
            GSM.setState(GSM.Crouch);
        }

        //Jump
        else if (Input.GetKeyDown(GSM.PSInput.kJump))
        {
            GSM.setState(GSM.Jump);
        }

        //Change Layer
        else if (Input.GetKeyDown(GSM.PSInput.kChangeLayerDown) || Input.GetKeyDown(GSM.PSInput.kChangeLayerUp))
        {
            if (Input.GetKeyDown(GSM.PSInput.kChangeLayerDown))
            {
                GSM.ChangeLayer.setLayerDir(false);
            }
            else
            {
                GSM.ChangeLayer.setLayerDir(true);
            }
            GSM.setState(GSM.ChangeLayer);
        }
    }
}
