using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentPatrolBehavoir : MonoBehaviour
{
    private NavMeshAgent agent;
    public float remainDist = .5f;
    public List<Transform> patrolPoints;
    private int i;
    
    private void Start()
    {
        i = 0;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < remainDist)
        {
            agent.destination = patrolPoints[i].position;
            i = (i + 1) % patrolPoints.Count;

        }
    }
}
