using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent), typeof(ParticleSpawner))]
public class PlayerMotor : MonoBehaviour
{
    private NavMeshAgent agent;

    private Interactable target;

    private bool hasSpawnedParticles = false;

    private ParticleSpawner particleSpawner;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        particleSpawner = GetComponent<ParticleSpawner>();
    }

    public void MoveToDestination(Vector3 destination)
    {
        StopMoving();
        StopAllCoroutines();
        EndInterAction();

        agent.isStopped = false;
        agent.destination = destination;

        SpawnMoveParticles(destination);
    }

    private void SpawnMoveParticles(Vector3 destination)
    {
        if (!hasSpawnedParticles)
        {
            particleSpawner.SpawnMovementParticles(destination);
            hasSpawnedParticles = true;
        }
    }

    public void MoveToInteractable(Vector3 destination, Interactable interactableToMoveTo, float distance)
    {
        if (target == null)
        {
            MoveToDestination(destination);
            StartCoroutine(CheckIfInRadius(interactableToMoveTo, distance));
        }
    }

    private IEnumerator CheckIfInRadius(Interactable targetToMoveto, float startDistance)
    {
        target = targetToMoveto;

        float distance = startDistance;

        while (distance >= target.radius && target != null)
        {
            distance = Vector3.Distance(transform.position, target.transform.position);
            yield return null;
        }

        if (target != null)
        {
            target.HandleInteraction();

            //Player in range of target so we move to target
            StopMoving();
        }
    }

    private void EndInterAction()
    {
        target.EndInteraction();
    }

    public void StopMoving()
    {
        agent.isStopped = true;
        target = null;
    }
}
