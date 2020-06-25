using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [Range(1,100)]
    public float radius = 3f;

    public float TimeOutAfterTrigger;

    [Range(0.0f, 10.0f), SerializeField]
    private float hoverIntensity = 1.5f;

    [SerializeField]
    private bool MovesAfterInteraction;

    public UnityEvent InteractionEnd;

    internal bool isInteracting = false;

    [HideInInspector]public bool IsActiveAndInteractable = true;
    [HideInInspector]public bool TimedOut = false;
    private NavMeshAgent agent;
    private PlayerMotor playerMotor;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void SavePlayerMotor(Transform player)
    {
        playerMotor = player.GetComponent<PlayerMotor>();
    }

    public virtual void HandleInteraction(Transform player)
    {
        if (playerMotor == null)
            SavePlayerMotor(player);

        playerMotor.SetDialogShown(true);

        isInteracting = true;

        if(agent != null)
        {
            agent.isStopped = true;
        }
    }

    public virtual void ActivateInteractable()
    {
        IsActiveAndInteractable = true;
    }

    public virtual void DeactivateInteractable(SphereCollider collider)
    {
        IsActiveAndInteractable = false;

        SchrinkColliderRadius(collider);
    }

    private void SchrinkColliderRadius(SphereCollider collider)
    {
        float newRadius = 1;

        CapsuleCollider col = GetComponent<CapsuleCollider>();

        if (col != null)
        {
            newRadius = col.radius;
        }

        collider.radius = newRadius;
    }

    public virtual void EndInteraction()
    {
        playerMotor.SetDialogShown(false);

        if (isInteracting)
        {
            if (agent != null && MovesAfterInteraction)
            {
                agent.isStopped = false;
            }
            InteractionEnd.Invoke();
            isInteracting = false;
        }
    }

    public IEnumerator SetTimeOut()
    {
        TimedOut = true;
        yield return new WaitForSeconds(TimeOutAfterTrigger);
        TimedOut = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,radius);
    }

    void OnMouseEnter()
    {
        GetComponentInChildren<Renderer>().material.color = new Color(hoverIntensity, hoverIntensity, hoverIntensity);
    }

    void OnMouseExit()
    {
        GetComponentInChildren<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f);
    }
}
