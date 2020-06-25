﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent), typeof(ParticleSpawner))]
public class PlayerMotor : MonoBehaviour
{
    private NavMeshAgent agent;

    private AnimationTransition at;

    private Interactable target;

    private bool hasSpawnedParticles = false;

    private ParticleSpawner particleSpawner;

    private Interactable currentChair = null;

    private bool isDialogShown = false;
    private bool canStand = true;
    private bool hasOptions = false;

    private void Update()
    {
        if (agent.enabled)
        {
            if (agent.destination == transform.position || agent.isStopped)
            {
                at.WalkingAnimation(false);
                WalkingSoundManager.StopWalkingSound();
            }
        }
             
    }

    private void Start()
    {
        at = GetComponent<AnimationTransition>();
        agent = GetComponent<NavMeshAgent>();
        particleSpawner = GetComponent<ParticleSpawner>();
    }

    public void SetDialogShown(bool value)
    {
        isDialogShown = value;
    }

    public void SetSpawnParticles(bool value)
    {
        hasSpawnedParticles = value;
    }

    public void MoveToDestination(Vector3 destination)
    {
        if (!isDialogShown)
        {
            EndInterAction();
            CheckStandingUpFromChair();

            if (agent.enabled)
            {
                at.WalkingAnimation(true);
                WalkingSoundManager.PlayWalkingSound();

                ClearCurrentTarget();
                StopMoving();

                StopAllCoroutines();
                agent.isStopped = false;
                agent.SetDestination(destination);

                SpawnMoveParticles(destination);
            }
        }
    }

    public void setHasOptions(bool value)
    {
        hasOptions = value;
    }

    private void CheckStandingUpFromChair()
    {
        if (currentChair != null && CanStand)
        {
            currentChair.EndInteraction();
            currentChair = null;
        }
    }

    private void SpawnMoveParticles(Vector3 destination)
    {
        if (!hasSpawnedParticles)
        {
            particleSpawner.SpawnMovementParticles(destination);
            SetSpawnParticles(true);
        }
    }

    public void SpawnInteractableParticle(Vector3 destination)
    {
        if (!hasSpawnedParticles)
        {
            particleSpawner.SpawnInteractableClickParticles(destination);
            SetSpawnParticles(true);
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

    public void setTargetChair(Interactable TargetChair)
    {
        currentChair = TargetChair;
    }

    public void SetTarget(Interactable TargetInteractable)
    {
        target = TargetInteractable;
    }

    private IEnumerator CheckIfInRadius(Interactable targetToMoveto, float startDistance)
    {
        SetTarget(targetToMoveto);

        float distance = startDistance;

        while (distance >= target.radius && target != null)
        {
            distance = Vector3.Distance(transform.position, target.transform.position);
            yield return null;
        }
        
        if (target != null)
        {
            target.HandleInteraction(transform);
            
            //Player in range of target so we move to target
            StopMoving();
        }
    }

    public void EndInterAction()
    {
        if (target != null)
        {
            target.EndInteraction();
        }
    }

    private void ClearCurrentTarget()
    {
        if (target != null && 
            !target.TimedOut)
        {
            target = null;
        }
    }

    public void StopMoving()
    {
        if (agent.enabled)
        {
            agent.isStopped = true;
        }        
    }

    public bool CanStand { get => canStand; set => canStand = value; }
    public bool HasOptions { private set => hasOptions = value; get => hasOptions; }
    public Interactable CurrentChair { get => currentChair; }
}
