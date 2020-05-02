using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Vector3 targetPos = new Vector3();

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (!isProvoked) { SearchForTarget(); }
    }

    private void SearchForTarget()
    {
        if (distanceToTarget <= chaseRange)
        {
            EngageTarget();
        }
        else
        {
            animator.ResetTrigger("Move");
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
        ChaseTarget();
        StartCoroutine(NoticeTarget());
    }

    private IEnumerator NoticeTarget()
    {
        while (isProvoked)
        {
            yield return new WaitForSeconds(.5f);
            if ((distanceToTarget <= chaseRange) || (navMeshAgent.isStopped)) { isProvoked = false; }
        }
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            animator.SetBool("Attack", false);
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        targetPos = target.position;
        animator.SetTrigger("Move");
        navMeshAgent.SetDestination(targetPos);
    }

    private void AttackTarget()
    {
        FaceTarget();
        animator.SetBool("Attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
