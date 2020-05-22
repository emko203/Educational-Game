using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    [Header("Offsets")]
    [Range(0,100)]
    public float zOffset = 0;
    [Range(0, 100)]
    public float xOffset = 0;
    [Range(0, 100)]
    public float yOffset = 0;

    [Header("Delay")]
    [Range(0, 50)]
    public float delay = 0;

    public Transform PlayerToFollow;

    private Transform camPos;

    // Start is called before the first frame update
    void Start()
    {
        camPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camPos.position.x != PlayerToFollow.position.x || 
            camPos.position.y != PlayerToFollow.position.y)
        {
           // StartCoroutine(MoveCam());
        }
    }

    IEnumerator MoveCam()
    {
        bool GotToDestination = false;

        yield return new WaitForSeconds(delay);

        while (!GotToDestination)
        {
            Vector3 LerpVector = Vector3.Lerp(camPos.position, PlayerToFollow.position,Time.deltaTime);
            if (LerpVector != PlayerToFollow.position)
            {
                camPos.position = new Vector3(LerpVector.x + xOffset, LerpVector.y + yOffset, LerpVector.z + zOffset);
            }
            else
            {
                GotToDestination = true;
            }
        }
    }
}
