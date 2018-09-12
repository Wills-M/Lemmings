using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lemming : MonoBehaviour {

    public Color color;
    public Transform goal;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.isOnNavMesh)
        {
            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(goal.position, path);
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                agent.path = path;
            }
        }
    }

}
