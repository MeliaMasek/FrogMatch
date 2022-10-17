using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent((typeof(NavMeshAgent)))]
public class NavMeshBehavoir : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3Data playerloc;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = playerloc.value;
    }
}
