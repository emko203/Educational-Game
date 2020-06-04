using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent), typeof(ParticleSpawner))]
public class PlayerMovementController : MonoBehaviour
{
    public Camera cam;

    public Interactable target;

    public LayerMask MovementMask;

    private NavMeshAgent agent;
    private ParticleSpawner particleSpawner;
    private bool mouseDown = false;
    private bool hasSpawnedParticles = false;
    private Vector2 mousePos = Vector2.zero;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        particleSpawner = GetComponent<ParticleSpawner>();
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
            StopAllCoroutines();
            agent.isStopped = false;

            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                //Clicked on interactable

                float distance = Vector3.Distance(transform.position, interactable.transform.position);

                if (distance < interactable.radius)
                {
                    //In range
                    interactable.HandleInteraction();
                }
                else
                {
                    //Not in range
                    agent.destination = hit.point;
                    StartCoroutine(CheckIfInRadius(interactable, distance));
                }

                Debug.Log("This is interactable");
            }
            else
            {
                //just move to point
                agent.destination = hit.point;
                if (!hasSpawnedParticles)
                    {
                        particleSpawner.SpawnMovementParticles(hit.point);
                        hasSpawnedParticles = true;
                    }
            }
        }
    }

    private IEnumerator CheckIfInRadius(Interactable target, float startDistance)
    {
        float distance = startDistance;

        while(distance >= target.radius)
        {
            distance = Vector3.Distance(transform.position, target.transform.position);
            yield return null;
        }

        agent.isStopped = true;
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
