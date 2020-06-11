using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Range(1,100)]
    public float radius = 3f;
    
    [HideInInspector]
    public bool IsActiveAndInteractable = true;

    public virtual void HandleInteraction()
    {

    }

    public virtual void ActivateInteractable()
    {
        IsActiveAndInteractable = true;
    }

    public virtual void DeactivateInteractable()
    {
        IsActiveAndInteractable = false;
    }

    public virtual void EndInteraction()
    {

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
