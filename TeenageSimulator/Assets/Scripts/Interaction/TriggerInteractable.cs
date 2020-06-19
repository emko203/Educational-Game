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

    public override void HandleInteraction()
    {
        base.HandleInteraction();
    }

    private void setRangeOfCollider()
    {
        //SphereCollider collider = GetComponent<SphereCollider>();

        //collider.radius = radius;
        //collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsActiveAndInteractable)
        {
            PlayerMotor player = other.gameObject.GetComponent<PlayerMotor>();

            if (player != null)
            {
                HandleInteraction();
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
