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
    [SerializeField]
    private Button OptionButton;
    [SerializeField]
    private Canvas canvas;
    private List<GameObject> ButtonInstances = new List<GameObject>();

    public void HandleDialog()
    {
        TextBox.text = TargetDialog.Text;
        TextBox.gameObject.SetActive(true);
        GenerateOptionButtons();
    }

    public override void HandleInteraction()
    {
        HandleDialog();
    }

    public override void EndInteraction()
    {
        TextBox.gameObject.SetActive(false);
        CleanUpButtons();
    }

    private void GenerateOptionButtons()
    {
        int itterator = 1;
        float availableWidth = TextBox.minWidth;
        float WidthStep = availableWidth / TargetDialog.Options.Count;
        foreach (Option option in TargetDialog.Options)
        {
            GameObject buttonInstance = InstantiateOptionButton(itterator);

            ButtonInstances.Add(buttonInstance);

            buttonInstance.GetComponentInChildren<Text>().text = option.Text;
            buttonInstance.GetComponent<Button>().onClick.AddListener(delegate { ChangeTargetDialog(option.LinkedDialog); });
            itterator++;
        }
    }

    private GameObject InstantiateOptionButton(int itterator)
    {
        Button buttonInstance = Instantiate(OptionButton, canvas.transform);
        Vector2 centerPosition = canvas.pixelRect.center;
        Vector2 newPosition = centerPosition - new Vector2(0, 40 * itterator);
        buttonInstance.transform.position = newPosition;

        return buttonInstance.gameObject;
    }

    private void ChangeTargetDialog(Dialog newDialog)
    {
        TargetDialog = newDialog;
        CleanUpButtons();
        HandleDialog();
    }

    private void CleanUpButtons()
    {
        foreach (GameObject button in ButtonInstances)
        {
            button.GetComponent<Button>().onClick.RemoveAllListeners();
            Destroy(button);
        }
        ButtonInstances.RemoveRange(0, ButtonInstances.Count);
    }
}
