using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private AggroDetection aggroDetection;

    public NavMeshAgent NavMeshAgent { get; private set; }

    private Animator animator;
    private Transform target;

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAgrro += AggroDetection_OnAgrro;
    }

    private void AggroDetection_OnAgrro(Transform target)
    {
        this.target = target;
        NavMeshAgent.SetDestination(target.position);
        //GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
    }

    private void Update()
    {
        if(target != null)
        {
            NavMeshAgent.SetDestination(target.position);
            float currentSpeed = NavMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", currentSpeed);
        }
  
    }


}
