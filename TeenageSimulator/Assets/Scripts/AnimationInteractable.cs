using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInteractable : Interactable
{
    public Animator animator;
    public override void HandleInteraction(Transform player)
    {

        base.HandleInteraction(player);
    }

    public override void EndInteraction()
    {
        base.EndInteraction();
    }
}
