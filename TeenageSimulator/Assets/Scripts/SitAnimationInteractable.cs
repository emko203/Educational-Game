using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitAnimationInteractable : AnimationInteractable
{
    //private GameObject getPlayer() 
    //{ 
    //    ge
    //}

    public GameObject player;
    private Transform tf;
    private void Start()
    {
        tf = player.GetComponent<Transform>();
    }

    public override void HandleInteraction()
    {
        tf.transform.position = new Vector3(3, 3, 3);
        animator.SetBool("isSitting", true);
        base.HandleInteraction();
    }

    public override void EndInteraction()
    {
        animator.SetBool("isSitting", false);
        base.EndInteraction();
    }


}
