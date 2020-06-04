using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent), typeof(ParticleSpawner))]
public class PlayerMovementController : MonoBehaviour
{
    public Camera cam;

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
            MoveCharacter(mousePos);
        }
    }

    private void MoveCharacter(Vector2 mousePosition)
    {
            Ray ray = cam.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, MovementMask))
            {
                agent.destination = hit.point;
                if (!hasSpawnedParticles)
                    {
                        particleSpawner.SpawnMovementParticles(hit.point);
                        hasSpawnedParticles = true;
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
