using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
//Code borrowed from and modified user robertbu on UnityAnswers "https://answers.unity.com/questions/630670/rotate-2d-sprite-towards-moving-direction.html"

public class AgentBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        Vector3 moveDirection = gameObject.transform.position; 
        if (moveDirection != Vector3.zero) 
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }    
    }
}
