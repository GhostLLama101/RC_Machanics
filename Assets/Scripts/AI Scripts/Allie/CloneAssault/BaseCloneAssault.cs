using UnityEngine;
using UnityEngine.AI;

public class BaseCloneAssault : BaseCloneStateMachine<BaseCloneAssault>
{
    // Uses the base class default (idlestate). Override to start elsewhere:
    // public override CloneState<GuardClone> InitialState => runningstate;

    protected override void Start()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        base.Start(); // enters the initial state
    }

    protected override void Update()
    {
        base.Update(); // runs CurrentState.UpdateState and click-to-move

        // Add any clone-specific logic here
    }
}
