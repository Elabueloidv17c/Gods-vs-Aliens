using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokiStateMachine : GodStateMachine
{
    
    public GodChangeLayerState ChangeLayer;
    public GodCrouchState      Crouch;
    public GodCrouchWalkState  CrouchWalk;
    public GodDieState         Die;
    public GodIdleState        Idle;
    public GodJumpState        Jump;
    public GodRunState         Run;
    public GodWalkState        Walk;

    // Start is called before the first frame update
    void Start()
    {
        godStack = new Stack<GodState>();

        ChangeLayer = gameObject.AddComponent(typeof(GodChangeLayerState)) as GodChangeLayerState;
        Crouch = gameObject.AddComponent(typeof(GodCrouchState)) as GodCrouchState;
        CrouchWalk = gameObject.AddComponent(typeof(GodCrouchWalkState)) as GodCrouchWalkState;
        Die = gameObject.AddComponent(typeof(GodDieState)) as GodDieState;
        Idle = gameObject.AddComponent(typeof(GodIdleState)) as GodIdleState;
        Jump = gameObject.AddComponent(typeof(GodJumpState)) as GodJumpState;
        Run = gameObject.AddComponent(typeof(GodRunState)) as GodRunState;
        Walk = gameObject.AddComponent(typeof(GodWalkState)) as GodWalkState;

        pushState(Idle);
    }

    // Update is called once per frame
    void Update()
    {
        godStack.Peek().onUpdate();
    }
}
