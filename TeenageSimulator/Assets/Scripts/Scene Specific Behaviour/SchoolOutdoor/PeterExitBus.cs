using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeterExitBus : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    private NavMeshAgent agent;

    private void Awake()
    {
        character.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
    }
    private void LateUpdate()
    {
        float distance = agent.remainingDistance;
        if (agent.destination != null && !agent.pathPending && distance != 0)
        {
            if((distance <= 15))
            {
                character.SetActive(true);
                Destroy(this);
            }
        }
    }
}
