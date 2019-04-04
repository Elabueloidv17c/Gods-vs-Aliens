using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokiStateATK : GodState
{
    public float atkDuration;
    public float atkTimer;
    public float followUpTimer;
    public int atkCount;
    public bool attacked;
    public GameObject hitBox;

    public override void onEnter()
    {
        attacked = false;
        atkTimer = 0;
        atkCount = 0;
        followUpTimer = 0;
        atkDuration = GSM.PSInput.m_atkDuration;
        hitBox = GSM.PSInput.hitbox_0;
        GameObject clone = Instantiate(hitBox, transform);
    }

    public override void onUpdate()
    {
        
        if (Input.GetKeyDown(GSM.PSInput.kATK))
        {
            if (atkCount < 2)
            {
                attacked = true;
                ++atkCount;
            }
        }

        if (!attacked)
        {
            atkTimer += Time.deltaTime;
        }
        else
        {
            followUpTimer += Time.deltaTime;
            if (followUpTimer >= GSM.PSInput.m_atkFollowUpDelay)
            {
                GameObject clone = Instantiate(hitBox);
                atkTimer -= Time.deltaTime;
                attacked = false;
                followUpTimer = 0;
                GSM.PSInput.m_currentStamina -= 30;
            }
        }

        if (atkTimer >= atkDuration)
        {
            GSM.setState(GSM.Idle);
        }
    }

    public override void onExit()
    {

    }
}
