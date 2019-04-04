using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodCrouchWalkState : GodState
{
    public override void onEnter()
    {

    }
    public override void onExit()
    {
        GSM.PSInput.m_lastState = LastState.CrouchWalk;
    }
    public override void onUpdate()
    {
        if ((Input.GetKeyUp(GSM.PSInput.kRight) || Input.GetKeyUp(GSM.PSInput.kRight)) && GSM.rb.velocity.x == 0)
        {
            GSM.setState(GSM.Crouch);
        }
        if (Input.GetKeyUp(GSM.PSInput.kDown))
        {
            GSM.m_collider.size = new Vector2(GSM.m_collider.size.x, GSM.m_collider.size.y * 2);
            GSM.m_collider.offset = new Vector2(GSM.m_collider.offset.x, GSM.m_collider.offset.y + GSM.m_collider.size.y * 2);
            GSM.setState(GSM.Walk);
        }
    }
}
