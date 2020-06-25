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
    NavMeshAgent navmeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;


    void Start()
    {

        navmeshAgent = GetComponent<NavMeshAgent>();
        health= GetComponent<EnemyHealth>();
    }
  
    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navmeshAgent.enabled = false;
            return;
        }

        distanceToTarget = Vector3.Distance(target.position,transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            navmeshAgent.SetDestination(target.position);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position,chaseRange);
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navmeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navmeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navmeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        //Debug.Log(name + " has seeked and is destroying " + target.name);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized; // sets the magnitute of the vector to 1.. wich means we want to change only the rotation
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); //Quatonions are responsible for rotations
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime *  turnSpeed);

    }

}
