using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerScript : AiState
{
    [SerializeField] Transform followObject;
    private float maxTime = 1.0f;
    private float maxDistance = 1.0f;
    private float timer = 0.0f;
    public void Enter(AiAgent agent)
    {
    }

    public void Exit(AiAgent agent)
    {
    }

    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }

    public void Update(AiAgent agent)
    {

        if (!agent.enabled)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = followObject.position;
        }

        if (timer < 0.0f)
        {
            Vector3 direction = (followObject.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if (direction.sqrMagnitude > maxDistance * maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = followObject.position;
                }
            }
            timer = maxTime;
        }
    }
}
