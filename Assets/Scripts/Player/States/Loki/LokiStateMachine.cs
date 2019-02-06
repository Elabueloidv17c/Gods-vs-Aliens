using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokiStateMachine : GodStateMachine
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PSInput = GetComponent<PlayerInputStats>();
        godStack = new Stack<GodState>();

        ChangeLayer = gameObject.AddComponent(typeof(GodChangeLayerState)) as GodChangeLayerState;
        ChangeLayer.setFSM(this);
        Crouch = gameObject.AddComponent(typeof(GodCrouchState)) as GodCrouchState;
        Crouch.setFSM(this);
        CrouchWalk = gameObject.AddComponent(typeof(GodCrouchWalkState)) as GodCrouchWalkState;
        CrouchWalk.setFSM(this);
        Die = gameObject.AddComponent(typeof(GodDieState)) as GodDieState;
        Die.setFSM(this);
        Idle = gameObject.AddComponent(typeof(GodIdleState)) as GodIdleState;
        Idle.setFSM(this);
        Jump = gameObject.AddComponent(typeof(GodJumpState)) as GodJumpState;
        Jump.setFSM(this);
        Run = gameObject.AddComponent(typeof(GodRunState)) as GodRunState;
        Run.setFSM(this);
        Walk = gameObject.AddComponent(typeof(GodWalkState)) as GodWalkState;
        Walk.setFSM(this);

        pushState(Idle);
    }

    // Update is called once per frame
    void Update()
    {
        godStack.Peek().onUpdate();
    }
}
