using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TriggerInteractable : DialogInteractable
{
    private void Awake()
    {
        setRangeOfCollider();
    }

    private void setRangeOfCollider()
    {
        SphereCollider collider = GetComponent<SphereCollider>();

        collider.radius = this.radius;
    }

    public override void EndInteraction()
    {
        base.EndInteraction();
    }

    public override void HandleInteraction()
    {
        base.HandleInteraction();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMotor player = other.gameObject.GetComponent<PlayerMotor>();

        if (player != null)
        {
            HandleInteraction();
            player.StopMoving();
        }
    }
}
