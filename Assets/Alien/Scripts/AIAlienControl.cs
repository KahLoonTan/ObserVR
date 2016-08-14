using System;
using UnityEngine;

[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (AlienCharacter))]
public class AIAlienControl : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public AlienCharacter character { get; private set; } // the character we are controlling
    public Transform target;                                    // target to aim for


    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<AlienCharacter>();

	    agent.updateRotation = false;
	    agent.updatePosition = true;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            character.Dead();
            agent.Stop();
            GetComponent<AlienLight>().switchedOn = false;
        }

        if (target != null)
            agent.SetDestination(target.position);

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity);
        else
            character.Move(Vector3.zero);
    }
    
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
