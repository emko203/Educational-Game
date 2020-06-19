using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [Range(1,100)]
    public float radius = 3f;

    public float TimeOutAfterTrigger;

    [Range(0.0f, 10.0f), SerializeField]
    private float hoverIntensity = 1.5f;

    [SerializeField]
    private bool MovesAfterInteraction;

    [HideInInspector]public bool IsActiveAndInteractable = true;
    [HideInInspector]public bool TimedOut = false;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public virtual void HandleInteraction()
    {
        if(agent != null)
        {
            agent.isStopped = true;
        }
    }

    public virtual void ActivateInteractable()
    {
        IsActiveAndInteractable = true;
    }

    public virtual void DeactivateInteractable()
    {
        IsActiveAndInteractable = false;
    }

    public virtual void EndInteraction()
    {
        if (agent != null && MovesAfterInteraction)
        {
            agent.isStopped = false;
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
