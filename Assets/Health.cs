using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    AiAgent agent;

    void Start()
    {
        agent = GetComponent<AiAgent>();
        currentHealth = maxHealth;

        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidbodies)
        {
            Hitbox hitbox = rigidbody.gameObject.AddComponent<Hitbox>();
            hitbox.health = this;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
        agent.stateMachine.ChangeState(AiStateId.Death);
    }
}
