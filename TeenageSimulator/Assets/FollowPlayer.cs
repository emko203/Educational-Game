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

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + xOffset, transform.position.y, player.position.z + zOffset);
    }
}
