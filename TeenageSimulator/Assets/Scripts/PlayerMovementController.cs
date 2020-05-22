using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovementController : MonoBehaviour
{
    public Camera cam;

    public LayerMask MovementMask;

    private NavMeshAgent agent;
    private bool mouseDown = false;
    private Vector3 mousePos = Vector3.zero;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseDown = Input.GetMouseButtonDown(1);

        if (mouseDown)
        {
            mousePos = Input.mousePosition;

            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
            Ray ray = cam.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, MovementMask))
            {
                //move our player to hit
                agent.destination = hit.point;
            }
    }
}
