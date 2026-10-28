using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Helpers : MonoBehaviour
{
    public static void GoTwards(NavMeshAgent agent, RaycastHit hitInfo)
    {
        agent.SetDestination(hitInfo.point);
    }
    
    public static void GoTwards(NavMeshAgent agent, GameObject clone, RaycastHit hitInfo) // for later when a clone is selected
    {
        agent.SetDestination(hitInfo.point);
    }
}
