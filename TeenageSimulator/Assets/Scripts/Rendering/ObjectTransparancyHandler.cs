using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransparancyHandler : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    Material transparantMaterial;
    [SerializeField]
    LayerMask transparentMask;

    private GameObject currentTransparentObject;
    private Material currentTransparentObjectOriginalMaterial;
    private void FixedUpdate()
    {
        HandleTransparacy(GetObscuringObject(SendRayToCamera()));
    }

    private RaycastHit SendRayToCamera()
    {
        Ray ray = new Ray(transform.position, cam.ScreenToWorldPoint(cam.transform.position));
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo, 300, transparentMask);
        return hitInfo;
    }

    private GameObject GetObscuringObject(RaycastHit raycast)
    {
        if(raycast.collider != null)
        {
            return raycast.transform.gameObject;
        }
        else
        {
            return null;
        }
    }

    private void HandleTransparacy(GameObject targetGameObject)
    {
        if(currentTransparentObject != null)
        {
            SetOpaque(currentTransparentObject);
            SetTransparent(targetGameObject);
        }
        else
        {
            SetTransparent(targetGameObject);
        }
    }

    private void SetTransparent(GameObject targetGameObject)
    {
        if (targetGameObject != null && targetGameObject != gameObject)
        {
            currentTransparentObject = targetGameObject;
            currentTransparentObjectOriginalMaterial = targetGameObject.GetComponent<Renderer>().material;
            Material targetMaterial;
            targetMaterial = transparantMaterial;
            Color newColor = targetMaterial.color;
            newColor.a = 0;
            targetMaterial.color = newColor;
            targetGameObject.GetComponent<Renderer>().material = targetMaterial;
        }
    }

    private void SetOpaque(GameObject targetGameObject)
    {
        if (targetGameObject != null && targetGameObject != gameObject)
        {
            targetGameObject.GetComponent<Renderer>().material = currentTransparentObjectOriginalMaterial;
        }
    }
}
