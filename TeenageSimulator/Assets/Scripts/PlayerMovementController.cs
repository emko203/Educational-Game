using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovementController : MonoBehaviour
{
    public Camera cam;

    public LayerMask MovementMask;

    private NavMeshAgent agent;
    private bool mouseDown = false;
    private Vector2 mousePos = Vector2.zero;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       // mouseDown = Input.GetMouseButton(1);

        if (mouseDown)
        {
           // mousePos = Input.mousePosition;

            MoveCharacter(mousePos);
        }
    }

    private void MoveCharacter(Vector2 mousePosition)
    {
            Ray ray = cam.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 300, MovementMask))
            {
                agent.destination = hit.point;
            }
    }

    public void PassMousePosition(InputAction.CallbackContext context)
    {
        context.action.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        context.action.canceled += ctx => mousePos = Vector2.zero;

    }

    public void PassMouseButtonClick(InputAction.CallbackContext context)
    {
        context.action.performed += ctx => mouseDown = true;
        context.action.canceled += ctx => mouseDown = false;
    }
}
