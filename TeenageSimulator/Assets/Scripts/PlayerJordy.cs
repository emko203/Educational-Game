using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerJordy : MonoBehaviour
{
    public Camera cam;

    public LayerMask MovementMask;
    public NavMeshAgent agent;

    public Transform Player;

    private bool mouseDown = false;


    // Update is called once per frame
    void Update()
    {
        mouseDown = Input.GetMouseButtonDown(1);

        if (mouseDown)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, MovementMask))
            {
                //move our player to hit
                agent.destination = hit.point;
            }
        }
    }
}