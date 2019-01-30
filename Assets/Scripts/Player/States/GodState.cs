using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GodState : MonoBehaviour
{
    /**
     ************************
     * || WARNING || WARNING || WARNING || WARNING || WARNING ||
     * 
     * Loki's FSM to be used by ONLY and EXCLUSIVELY in LOKI states 
     * 
     * || WARNING || WARNING || WARNING || WARNING || WARNING ||
     ************************
     */
    private LokiStateMachine m_LokiSM;
    public LokiStateMachine LokiSM
    {
        get
        {
            if (null == m_LokiSM)
            {
                m_LokiSM = FindObjectOfType<LokiStateMachine>();
            }

            return m_LokiSM;
        }
    }

    public abstract void onEnter();
    public abstract void onExit();
    public abstract void onUpdate();
}
