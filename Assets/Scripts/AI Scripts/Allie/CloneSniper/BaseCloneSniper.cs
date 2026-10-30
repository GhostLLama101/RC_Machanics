using UnityEngine;
using UnityEngine.AI;

public class BaseCloneSniper : BaseCloneStateMachine<BaseCloneSniper>
{

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
