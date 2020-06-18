using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class NPCMovementController : MonoBehaviour
{
    [SerializeField]
    private List<waypointInfo> waypoints;
    [SerializeField]
    private bool loopPath;

    [Serializable]
    private class waypointInfo
    {
        [SerializeField]
        float waitTime;
        [SerializeField]
        Transform location;
        public waypointInfo(float waitTime, Transform location)
        {
            this.waitTime = waitTime;
            this.location = location;
        }

        public float GetWaitTime()
        {
            return waitTime;
        }
        public Transform GetLocation()
        {
            return location;
        }
    }

    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        EnableMovement();
    }

    public void EnableMovement()
    {
        StartCoroutine(NpcPathHandler());
    }

    private bool AtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator NpcPathHandler()
    {
        foreach (waypointInfo waypoint in waypoints)
        {
            while (!AtDestination())
            {
                yield return null;
            }
            yield return new WaitForSeconds(waypoint.GetWaitTime());
            agent.SetDestination(waypoint.GetLocation().position);
        }
        if (loopPath)
        {
            StartCoroutine(NpcPathHandler());
        }
    }
}
