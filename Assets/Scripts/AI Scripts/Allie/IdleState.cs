using System;
using UnityEngine;
// IdleState works with some type T. It extends CloneState<T>.
// T must be a clone, meaning a class that inherits from CloneStateMachine<T>
public class IdleState<T> : CloneState<T> where T : BaseCloneStateMachine<T>
{
    //each state needs the animation so it can run the animation
    // idk how this will work with splitting the animation
    //each clone type will have a weapon attached to it
    // that will get pass around with its properties

    public override void EnterState(T clone)
    {
        
    }

    public override void UpdateState(T clone)
    {
        
    }

    public override void ExitState(T clone)
    {
        
    }
}
