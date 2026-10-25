using UnityEngine;
using UnityEngine.AI;

public class CloneSniper : CloneStateMachine<CloneSniper>
{
    // Uses the base class default (idlestate). Override to start elsewhere:
    // public override CloneState<GuardClone> InitialState => runningstate;

    protected override void Start()
    {
        // Auto-grab references so you don't have to assign them manually
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (cam == null) cam = Camera.main;

        base.Start(); // enters the initial state
    }

    protected override void Update()
    {
        base.Update(); // runs CurrentState.UpdateState and click-to-move

        // Add any clone-specific logic here
    }
}
