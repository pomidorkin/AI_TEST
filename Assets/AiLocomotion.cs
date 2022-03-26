using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiLocomotion : MonoBehaviour
{
    [SerializeField] Transform followObject;
    private float maxTime = 1.0f;
    private float maxDistance = 1.0f;
    NavMeshAgent agent;

    private float timer = 0.0f;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            float sqdDistance = (followObject.position - agent.destination).sqrMagnitude;
            if (sqdDistance > maxDistance * maxDistance)
            {
                agent.destination = followObject.position;
            }
            timer = maxTime;
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
