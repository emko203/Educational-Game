using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeterExitBus : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void LateUpdate()
    {
        if (!agent.pathPending)
        {
            float distance = agent.remainingDistance;
            if((distance <= 15))
            {
                character.SetActive(true);
                Destroy(this);
            }
        }
    }
}
