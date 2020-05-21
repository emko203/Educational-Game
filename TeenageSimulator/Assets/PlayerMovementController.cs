using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Camera cam;

    bool mouseDown = false;

    // Update is called once per frame
    void Update()
    {
        mouseDown = Input.GetMouseButtonDown(0);

        if (mouseDown)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //move our player to hit
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                print("We hit " + hit.collider.name + " " + hit.point);
            }
        }
    }
}
