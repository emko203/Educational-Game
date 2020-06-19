using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransition : MonoBehaviour
{
    public Animator animator;

    public void WalkingAnimation(bool isWalking) 
    {
        animator.SetBool("isWalking", isWalking);
    }
}
