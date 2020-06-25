using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask MovementMask;

    private PlayerMotor motor;
    private bool mouseDown = false;
    private Vector2 mousePos = Vector2.zero;
    public Animator animator;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDown)
        {
            mousePos = Input.mousePosition;           
            MoveCharacter(mousePos);
        }
    }

    private void MoveCharacter(Vector2 mousePosition)
    {
        //if we have the mouse over our ui system we dont interact with the world
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = cam.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 300, MovementMask))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null && interactable.GetType() != typeof(TriggerInteractable))
                {
                    //Clicked on interactable so we spawn particle
                    motor.SpawnInteractableParticle(interactable.transform.position);

                    //Calculate distance to the interactable
                    float distance = Vector3.Distance(transform.position, interactable.transform.position);

                    if (distance < interactable.radius)
                    {
                        //In range so we just handle the interaction
                        interactable.HandleInteraction(transform);
                    }

                    //Make sure we face the interactable or move to it if we are not in range
                    motor.MoveToInteractable(interactable.transform.position, interactable, distance);

                }
                else
                {
                    //Just move to point on ground
                    motor.MoveToDestination(hit.point);
                }
            }
    }
}

    

    public void PassMousePosition(InputAction.CallbackContext context)
    {
       // context.action.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
       // context.action.canceled += ctx => mousePos = Vector2.zero;
    }

    public void PassMouseButtonClick(InputAction.CallbackContext context)
    {
        context.action.performed += ctx => mouseDown = true;
        context.action.canceled += ctx => mouseDown = false;
        context.action.performed += ctx => motor.SetSpawnParticles(false);
    }
}
