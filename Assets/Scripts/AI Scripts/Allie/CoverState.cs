using UnityEngine;

public class CoverState<T> : CloneState<T> where T: BaseCloneStateMachine<T>
{
    // this is used for when they go behind cover they should be in the cover state
    // they should go back to the fallow state if recalled
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
