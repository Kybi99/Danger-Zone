using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackRefreshRate;
    public AudioSource gunFireSource;
    private AggroDetection aggroDetection;
    private Health healthTarget;
    private float attackTimer;
    public Health script;

    private void Awake()
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAgrro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        Health health = target.GetComponent<Health>();
        if(health != null)
        {
            healthTarget = health;
        }
    }

    private void Update()
    {
        if (healthTarget != null)
        {
            attackTimer += Time.deltaTime;
            if (CanAttack())
            {
                Attack();
            }
        }
    }

    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }

    private void Attack()
    {
        if (script.currentHealth != 0) {
            attackTimer = 0;
            healthTarget.TakeDamage(1);
            gunFireSource.Play();
        }
        
    }

}
