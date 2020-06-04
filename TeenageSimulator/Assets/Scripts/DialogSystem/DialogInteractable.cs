using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInteractable : Interactable
{
    [SerializeField]
    private Dialog TargetDialog;
    [SerializeField]
    private Text TextBox;

    public void HandleDialog()
    {
        TextBox.text = TargetDialog.Text;
        TextBox.gameObject.SetActive(true);
    }

    public override void HandleInteraction()
    {
        HandleDialog();
    }
}
