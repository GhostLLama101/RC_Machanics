using System;
using UnityEngine;

public abstract class CloneStateMachine<T>: MonoBehaviour where T : CloneStateMachine<T>
{
    
    public IdleState<T> idlestate =  new IdleState<T>();
    public AttackState<T> attackstate = new AttackState<T>();
    public CrouchingState<T> crouchingstate = new CrouchingState<T>();
    public KnockedState<T> knockedstate = new KnockedState<T>();
    public DefenceState<T> defencestate = new DefenceState<T>();
    public RunningState<T> runningstate = new RunningState<T>();
    
    public virtual CloneState<T> InitialState => idlestate;
    public CloneState<T> CurrentState;

    protected virtual void Start()
    {
       ChangeState(InitialState);
    }

    protected virtual void Update()
    {
        CurrentState?.UpdateState((T)this);
    }

    public void ChangeState(CloneState<T> newState)
    {
        CurrentState?.ExitState((T)this);
        CurrentState = newState;
        CurrentState.EnterState((T)this);
    }

    public void Movement(CloneState<T> Clone)
    {
        // this is where we will add the clone movement
    }
}
