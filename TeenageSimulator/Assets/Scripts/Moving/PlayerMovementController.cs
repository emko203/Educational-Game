using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerMovementController : MonoBehaviour
{
    public Camera cam;
    public LayerMask MovementMask;

    private PlayerMotor motor;
    private bool mouseDown = false;
    private bool hasSpawnedParticles = false;
    private Vector2 mousePos = Vector2.zero;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        
    }

    // Update is called once per frame
    void Update()
    {
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
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                //Clicked on interactable

                //Calculate distance to the interactable
                float distance = Vector3.Distance(transform.position, interactable.transform.position);

                if (distance < interactable.radius)
                {
                    //In range so we just handle the interaction
                    interactable.HandleInteraction();
                }
                else
                {
                    //Not in range so we move toward interactable
                    motor.MoveToInteractable(interactable.transform.position, interactable, distance);
                }

            }
            else
            {
                //Just move to point on ground
                motor.MoveToDestination(hit.point);
            }
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
        context.action.performed += ctx => hasSpawnedParticles = false;
    }
}
