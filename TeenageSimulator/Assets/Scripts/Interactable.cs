using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Range(1,100)]
    public float radius = 3f;
    [Range(0.0f, 10.0f)]
    public float hoverIntensity = 1.5f;
    public GameObject mesh;

    public virtual void HandleInteraction()
    {

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
        mesh.GetComponent<Renderer>().material.color = new Color(hoverIntensity, hoverIntensity, hoverIntensity);
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on GameObject.");
        mesh.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f);
    }
}
