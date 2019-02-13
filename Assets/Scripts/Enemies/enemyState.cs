using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "PluggableAI/State")]
abstract public class enemyState : MonoBehaviour {

    /**
     * ************************
     * * Base class for enemy states
     * ************************
     * */
    public Color sceneGizmoColor = Color.grey;


    abstract public void onEnter(enemyStateMchn cntrl);
    abstract public void onUpdate(enemyStateMchn cntrl);
    abstract public void onExit(enemyStateMchn cntrl);
}
