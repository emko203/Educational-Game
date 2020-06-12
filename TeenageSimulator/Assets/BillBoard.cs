using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Transform cam;

    private void Start()
    {
        cam = Camera.current.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(cam.position);
    }
}
