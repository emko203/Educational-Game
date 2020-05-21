using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementController : MonoBehaviour
{
    public Camera cam;

    public LayerMask MovementMask;
    public NavMeshAgent agent;

    public Transform Player;

    private bool mouseDown = false;
    private float MovementWait = 0.5f;


    // Update is called once per frame
    void Update()
    {
        mouseDown = Input.GetMouseButtonDown(1);

        if (mouseDown)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, MovementMask))
            {
                StopAllCoroutines();
                //move our player to hit
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                //StartCoroutine(MoveToPoint(hit.point));
                agent.destination = hit.point;
            }
        }
    }

    IEnumerator MoveToPoint(Vector3 pointToMoveTo)
    {
        Vector3 LerpVector = Vector3.zero;

        while (Player.position != pointToMoveTo )
        {
            LerpVector = Vector3.Lerp(Player.position, pointToMoveTo, Time.deltaTime);

            Player.position = LerpVector;
            yield return null;
        }
    }
}
