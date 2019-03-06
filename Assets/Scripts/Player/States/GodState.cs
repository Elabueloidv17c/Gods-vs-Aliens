using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GodState : MonoBehaviour
{
    protected GodStateMachine GSM = null;

    public void setFSM(GodStateMachine FSM)
    {
        GSM = FSM;
    }

    public abstract void onEnter();
    public abstract void onExit();
    public abstract void onUpdate();
}
