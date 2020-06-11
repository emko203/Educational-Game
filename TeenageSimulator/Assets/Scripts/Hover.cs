using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    void OnMouseOver()
    {
        Debug.Log("Mouse is over GameObject.");
        gameObject.GetComponent<Renderer>().material.color = new Color(1.5f, 1.5f, 1.5f); 
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on GameObject.");
        gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f); 
    }
}
