using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodCrouchState : GodState
{
    public override void onEnter()
    {
        GSM.m_animator.SetBool("isCrounching", true);
        GSM.m_collider.size = new Vector2(GSM.m_collider.size.x, GSM.m_collider.size.y / 2);
        GSM.m_collider.offset = new Vector2(GSM.m_collider.offset.x, GSM.m_collider.offset.y - GSM.m_collider.size.y / 2);
    }
    public override void onExit()
    {
        GSM.m_animator.SetBool("isCrounching", false);
        GSM.m_collider.offset = new Vector2(GSM.m_collider.offset.x, GSM.m_collider.offset.y + GSM.m_collider.size.y / 2.0f);
        GSM.m_collider.size = new Vector2(GSM.m_collider.size.x, GSM.m_collider.size.y * 2);
        GSM.PSInput.m_lastState = LastState.Crouch;
    }
    public override void onUpdate()
    {
        if (Input.GetKeyUp(GSM.PSInput.kDown))
        {
            GSM.setState(GSM.Idle);
        }
        if (Input.GetKey(GSM.PSInput.kRight) || (Input.GetKey(GSM.PSInput.kLeft)))
        {
            GSM.setState(GSM.Walk);
        }
    }
}
