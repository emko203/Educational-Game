﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogInteractable : Interactable
{
    public Dialog TargetDialog;
    [SerializeField]
    private bool DoesSpawnBubbles = true;

    private Text TextBox;
    private Image TextBoxGraphic;
    private Transform OptionAnchor;
    private Button OptionButton;
    private Canvas canvas;
    private StatHandler statHandler;
    private TalkingSoundManager talkingSoundManager;

    private List<Bubble> lstBubbles = new List<Bubble>();
    private List<GameObject> ButtonInstances = new List<GameObject>();

    private TextBoxBehaviour dialogBox;

    private void Awake()
    {
        lstBubbles = GetComponentInChildren<BubbleHelper>().LstBubbles;
        
        HideBubbles();
    }


    private void FillBubbleList(Transform player)
    {
        BubbleHelper helper = GetComponentInChildren<BubbleHelper>();

        if (helper == null)
            helper = GetComponent<BubbleHelper>();

        if (helper == null)
            helper = player.GetComponentInChildren<BubbleHelper>();

        if (helper != null)
        {
            lstBubbles = helper.LstBubbles;
        }
        else
        {
            //still no helper on object :(?

        }
    }

    public void HandleDialog(PlayerMotor player)
    {
        if (TargetDialog != null)
        {
            PlayRandomTalkingClip();

            dialogBox.gameObject.SetActive(true);

            TextBox.text = TargetDialog.Text;

            dialogBox.RequestDialogBoxMove(TextBoxBehaviour.TextBoxState.Extended);

            if (TargetDialog.Options.Count > 0)
            {
                player.setHasOptions(true);
                GenerateOptionButtons(player);
            }
            else
            {
                player.setHasOptions(false);
            }
        }
    }

    private void PlayRandomTalkingClip()
    {
        if (talkingSoundManager != null)
        {
            talkingSoundManager.PlayRandomClip();
        }
    }

    public void TurnTimeOutOn()
    {
        StopAllCoroutines();

            StartCoroutine(SetTimeOut());

    }

    public override void HandleInteraction(Transform player)
    {
        if (TargetDialog != null)
        {
            DialogRequirementsContainer container = player.gameObject.GetComponent<DialogRequirementsContainer>();
            talkingSoundManager = container.talkingSoundManager;
            TextBox = container.TextBox;
            TextBoxGraphic = container.TextBoxGraphic;
            OptionAnchor = container.OptionAnchor;
            OptionButton = container.OptionButton;
            canvas = container.canvas;
            statHandler = container.statHandler;
            dialogBox = container.dialogBox.GetComponent<TextBoxBehaviour>();

            TurnTimeOutOn();
        }
        base.HandleInteraction(player);

        HandleDialog(player.GetComponent<PlayerMotor>());

        if (DoesSpawnBubbles)
        {
            SpawnBubble(player);
        }
    }

    private Bubble GetBubbleByType(EnumConversationType type, Transform player)
    {
        if (lstBubbles.Count <= 0)
            FillBubbleList(player);

        foreach (Bubble b in lstBubbles)
        {
            if (b.ConversationType == type)
            {
                return b;
            }
        }
        return null;
    }
    private void SpawnBubble(Transform player)
    {
        if (TargetDialog != null)
        {
            GetBubbleByType(TargetDialog.ConversationType, player).ShowBubble();
        }
    }

    private void HideBubbles()
    { 
        foreach (Bubble b in lstBubbles)
        {
            b.HideBubble();
        }
    }

    public override void EndInteraction()
    {
            if (!TimedOut && dialogBox != null && isInteracting)
            {
                dialogBox.RequestDialogBoxMove(TextBoxBehaviour.TextBoxState.Retracted);
                CleanUpButtons();
                HideBubbles();
            }
            base.EndInteraction();
    }



    private void GenerateOptionButtons(PlayerMotor player)
    {
        int itterator = 1;
        float availableWidth = TextBox.minWidth;
        float WidthStep = availableWidth / TargetDialog.Options.Count;

        foreach (Option option in TargetDialog.Options)
        {
            GameObject buttonInstance = InstantiateOptionButton(itterator);

            ButtonInstances.Add(buttonInstance);

            buttonInstance.GetComponentInChildren<Text>().text = option.Text;
            buttonInstance.GetComponent<Button>().onClick.AddListener(delegate { ChangeTargetDialog(option.LinkedDialog, player); });

            foreach (Option.StatChange statChange in option.GetStatChanges())
            {
                buttonInstance.GetComponent<Button>().onClick.AddListener(delegate { statHandler.ChangeStat(statChange.GetChangeAmount(), statChange.GetStat()); });
            }

            itterator++;
        }
    }

    private GameObject InstantiateOptionButton(int itterator)
    {
        Button buttonInstance = Instantiate(OptionButton, canvas.transform);
        Vector2 centerPosition = OptionAnchor.position;
        Vector2 newPosition = centerPosition + new Vector2(250 * (itterator -1) + 80, 0);
        buttonInstance.transform.position = newPosition;

        return buttonInstance.gameObject;
    }

    private void ChangeTargetDialog(Dialog newDialog, PlayerMotor player)
    {
        TargetDialog = newDialog;
        CleanUpButtons();
        HandleDialog(player);
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
