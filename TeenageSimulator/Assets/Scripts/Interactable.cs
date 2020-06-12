﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Range(1,100)]
    public float radius = 3f;

    [Range(0.0f, 10.0f), SerializeField]
    private float hoverIntensity = 1.5f;
    
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

    void OnMouseOver()
    {
        Debug.Log("Mouse is over GameObject.");
        GetComponentInChildren<Renderer>().material.color = new Color(hoverIntensity, hoverIntensity, hoverIntensity);
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on GameObject.");
        GetComponentInChildren<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f);
    }
}
