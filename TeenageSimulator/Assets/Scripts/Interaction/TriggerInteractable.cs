using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TriggerInteractable : DialogInteractable
{
    [Header("TriggerInteractble")]
    [SerializeField]
    private int MaxInteractions;

    private int currentInteractions = 0;

    private void Awake()
    {
        setRangeOfCollider();
    }

    public override void HandleInteraction(Transform player)
    {
        base.HandleInteraction(player);
    }

    private void setRangeOfCollider()
    {
        SphereCollider collider = GetComponent<SphereCollider>();

        collider.radius = radius / transform.localScale.x;
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsActiveAndInteractable)
        {
            PlayerMotor player = other.gameObject.GetComponent<PlayerMotor>();

            if (player != null)
            {
                HandleInteraction(other.transform);
                player.SetTarget(this);
                player.StopMoving();
            }

            CheckIfStillInteractable();
        }
    }

    private void CheckIfStillInteractable()
    {
        currentInteractions++;
        if (currentInteractions >= MaxInteractions)
        {
            DeactivateInteractable();
        }
    }
}
