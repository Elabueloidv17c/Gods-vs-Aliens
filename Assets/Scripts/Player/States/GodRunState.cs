using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodRunState : GodState
{

    public override void onEnter()
    {

    }

    public override void onExit()
    {

    }

    public override void onUpdate()
    {
        //--------------------------------------------------------------------------------------------------------------------
        //Logic
        //--------------------------------------------------------------------------------------------------------------------
        GSM.rb.velocity = new Vector2(Input.GetAxis("Horizontal") * GSM.PSInput.m_frunSpeed, GSM.rb.velocity.y);

        //--------------------------------------------------------------------------------------------------------------------
        //Transitions
        //--------------------------------------------------------------------------------------------------------------------

        //Idle
        if (GSM.rb.velocity.x == 0.0f)
        {
            GSM.setState(GSM.Idle);
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

        //Dash
        else if (Input.GetKeyDown(GSM.PSInput.kDash))
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
