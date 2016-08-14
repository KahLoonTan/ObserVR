using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(SimonCharacter))]
public class AISimonControl : MonoBehaviour
{

    public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public SimonCharacter character { get; private set; } // the character we are controlling
    public Transform target;                                    // target to aim for

    // Use this for initialization
    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<SimonCharacter>();

        agent.updateRotation = false;
        agent.updatePosition = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
