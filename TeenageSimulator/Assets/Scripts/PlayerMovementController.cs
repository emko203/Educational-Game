using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public Camera cam;

    public LayerMask MovementMask;
    public NavMeshAgent agent;

    public Transform Player;

    private bool mouseDown = false;
    private Vector2 mousePos = Vector2.zero;


    // Update is called once per frame
    void Update()
    {

        if (mouseDown)
        {
            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
        
            Ray ray = cam.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, MovementMask))
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
