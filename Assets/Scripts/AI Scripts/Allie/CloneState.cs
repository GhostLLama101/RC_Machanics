using System;
using UnityEngine;
//What state currently is has
public abstract class CloneState<T> where T : BaseCloneStateMachine<T>
{
    public abstract void EnterState(T type);
    //use UpdateState to change states
    public abstract void UpdateState(T type);
    //use ExitState to finalize any data not for updating states
    public abstract void ExitState(T type);
}

    
