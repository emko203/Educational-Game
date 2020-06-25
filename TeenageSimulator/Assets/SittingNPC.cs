using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingNPC : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isSitting", true);
    }
}
