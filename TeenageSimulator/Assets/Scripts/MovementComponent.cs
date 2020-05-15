using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    private Rigidbody _rigidbody;
    private Vector2 InputValue;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        HorizontalMovement(InputValue);
    }
    public void InputHandler(InputAction.CallbackContext context)
    {
        context.action.performed += ctx => InputValue = ctx.ReadValue<Vector2>();
        context.action.canceled += ctx => InputValue = Vector2.zero;
    }

    private void HorizontalMovement(Vector2 inputVector)
    {
        Vector3 newPosition = transform.position;
        newPosition.x += inputVector.x * Time.deltaTime * moveSpeed;
        newPosition.z += inputVector.y * Time.deltaTime * moveSpeed;
        transform.position = newPosition;
    }
}
