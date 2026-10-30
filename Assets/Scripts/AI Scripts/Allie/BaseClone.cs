using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseClone : MonoBehaviour
{
    protected NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void  MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
    }
}
