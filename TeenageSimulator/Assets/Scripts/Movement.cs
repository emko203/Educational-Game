using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float xInput;
    private float yInput;
    public float MovementSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        Vector3 PlayerVelocity = new Vector3(xInput * MovementSpeed, rb.velocity.y, yInput * MovementSpeed);
        rb.velocity = PlayerVelocity;
    }
}
