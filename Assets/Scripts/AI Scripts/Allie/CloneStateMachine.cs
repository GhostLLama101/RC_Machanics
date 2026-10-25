using System;
using UnityEngine;
using UnityEngine.AI;

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
    
    public NavMeshAgent agent;


    public Camera cam;
    
    private void Awake()
    {
    }

    protected virtual void Start()
    {
       ChangeState(InitialState);
    }

    protected virtual void Update()
    {
        CurrentState?.UpdateState((T)this);
        GoTwards();
    }

    public void ChangeState(CloneState<T> newState)
    {
        CurrentState?.ExitState((T)this);
        CurrentState = newState;
        CurrentState.EnterState((T)this);
    }

    public void GoTwards() // might need to become a helper in the future
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
           {
               this.agent.SetDestination(hit.point);
           }
        }
        // this takes in a clone came aobject an will set the destination of what is imputed
         // this will be based on the button clicked
    }
}
