using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class CloneStateMachine<T>: MonoBehaviour , IClone where T : CloneStateMachine<T>
{
    
    public IdleState<T> idlestate =  new IdleState<T>();
    public AttackState<T> attackstate = new AttackState<T>();
    public CrouchingState<T> crouchingstate = new CrouchingState<T>();
    public KnockedState<T> knockedstate = new KnockedState<T>();
    public DefenceState<T> defencestate = new DefenceState<T>();
    public RunningState<T> runningstate = new RunningState<T>();
    
    public virtual CloneState<T> InitialState => idlestate;
    public CloneState<T> CurrentState;
    
    public NavMeshAgent agent;
    
    //public Camera cam;
  

    protected virtual void Start()
    {
       ChangeState(InitialState);
    }

    protected virtual void Update()
    {
        CurrentState?.UpdateState((T)this);
        //GoTwards();
    }

    public void ChangeState(CloneState<T> newState)
    {
        CurrentState?.ExitState((T)this);
        CurrentState = newState;
        CurrentState.EnterState((T)this);
    }

    public void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
    }
}
