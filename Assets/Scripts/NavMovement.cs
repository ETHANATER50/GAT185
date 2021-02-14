using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMovement : Movement
{
    NavMeshAgent navMeshAgent;


    public override Vector3 Velocity
    {
        get { return navMeshAgent.velocity; }
        set { navMeshAgent.velocity = value; }
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.speed = speedMax;
        navMeshAgent.angularSpeed = rotationRate;
    }



    public override void ApplyForce(Vector3 force)
    {
        
    }

    public override void LateUpdate()
    {
        
    }

    public override void MoveTowards(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

    public override void stop()
    {
        navMeshAgent.isStopped = true;
    }

}
