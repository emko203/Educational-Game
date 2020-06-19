using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SitAnimationInteractable : AnimationInteractable
{
    [SerializeField]
    private Transform target;
    private Transform player;
    private Transform chairTransform;
    private float colHeight;
    private void Start()
    {
        chairTransform = GetComponent<Transform>();
    }

    public override void HandleInteraction(Transform player)
    {
        player.transform.position = new Vector3(chairTransform.position.x, chairTransform.position.y, chairTransform.position.z);
        player.rotation = new Quaternion(0,chairTransform.rotation.y,0,0);
        this.player = player;
        colHeight = this.player.GetComponent<CapsuleCollider>().height;
        this.player.GetComponent<CapsuleCollider>().height = 1.05f;
        this.player.GetComponent<NavMeshAgent>().enabled = false;
        player.LookAt(target);
        
        animator.SetBool("isSitting", true);
        base.HandleInteraction(player);
    }

    public override void EndInteraction()
    {
        animator.SetBool("isSitting", false);
        player.GetComponent<CapsuleCollider>().height = colHeight;
        this.player.GetComponent<NavMeshAgent>().enabled = true;
        base.EndInteraction();
    }


}
