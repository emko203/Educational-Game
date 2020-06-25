using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextBoxBehaviour : MonoBehaviour
{
    private RectTransform rectTransform;
    public TextBoxState boxState { get; private set; }

    public enum TextBoxState
    {
        Extended,
        Retracted
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        boxState = TextBoxState.Retracted;
    }
    private void MoveDialogBox(Vector2 endPositon, float duration)
    {
        rectTransform.DOKill();

        rectTransform.DOAnchorPos(endPositon, duration);

        if (boxState == TextBoxState.Retracted)
        {
            StartCoroutine(HideTextBox(duration));
        }
    }

    private IEnumerator HideTextBox(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (boxState == TextBoxState.Retracted)
        {
            gameObject.SetActive(false);
        }
        StopAllCoroutines();
    }

    public void RequestDialogBoxMove(TextBoxState state)
    {
        switch (state)
        {
            case TextBoxState.Extended:
                boxState = TextBoxState.Extended;
                MoveDialogBox(Vector2.zero, 1f);
                break;
            case TextBoxState.Retracted:
                boxState = TextBoxState.Retracted;
                MoveDialogBox(new Vector2(-999, 0), 1f);
                break;
            default:
                break;
        }
    }
}
