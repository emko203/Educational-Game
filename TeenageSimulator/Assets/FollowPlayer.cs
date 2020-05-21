using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    [Header("Offsets")]
    [Range(-100, 100)]
    public float zOffset = 0;
    [Range(-100, 100)]
    public float xOffset = 0;

    private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        cam.position = new Vector3(player.position.x + xOffset, cam.position.y, player.position.z + zOffset);
    }
}
