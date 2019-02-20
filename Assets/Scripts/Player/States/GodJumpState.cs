using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodJumpState : GodState
{
    public override void onEnter()
    {
        GSM.rb.velocity = new Vector2(GSM.rb.velocity.x, GSM.PSInput.m_fjumpForce);
    }

    public override void onExit()
    {

    }

    public override void onUpdate()
    {

    }
}
