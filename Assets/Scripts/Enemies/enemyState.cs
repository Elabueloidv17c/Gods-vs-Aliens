using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class enemyState : MonoBehaviour {

    /**
     * ************************
     * * Base class for enemy states
     * ************************
     * */
    protected enemyStateMchn ESM = null;

    public void setFSM(enemyStateMchn FSM)
    {
        ESM = FSM;
    }


    abstract public void onEnter();
    abstract public void onUpdate();
    abstract public void onExit();
}
