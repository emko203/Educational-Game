using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 26;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
