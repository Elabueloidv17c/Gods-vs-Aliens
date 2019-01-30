using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodStateMachine : MonoBehaviour
{
    public Stack<GodState> godStack;

    public void setState(GodState newState)
    {
        godStack.Peek().onExit();
        godStack.Pop();
        godStack.Push(newState);
        godStack.Peek().onEnter();
    }

    public void pushState(GodState newState)
    {
        godStack.Push(newState);
        godStack.Peek().onEnter();
    }

    public void popState()
    {
        godStack.Peek().onExit();
        godStack.Pop();
    }
}
