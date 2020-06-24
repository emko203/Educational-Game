using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpecificDialog : MonoBehaviour
{
    DialogInteractable targetInteractable;
    Dialog targetDialog;

    public void StartDialogOnInteractable(Transform player)
    {
        targetInteractable.TargetDialog = targetDialog;
        targetInteractable.HandleInteraction(player);
    }

    public void SetTargetInteractable(DialogInteractable newTarget)
    {
        targetInteractable = newTarget;
    }

    public void SetTargetDialog(Dialog newTarget)
    {
        targetDialog = newTarget;
    }
}
