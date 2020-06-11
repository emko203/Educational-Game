using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer bubbleSprite;
    [SerializeField]
    private EnumConversationType conversationType;

    public EnumConversationType ConversationType { get => conversationType; }

    public void ShowBubble()
    {
        gameObject.SetActive(true);
    }

    public void HideBubble() 
    {
        gameObject.SetActive(false);
    }
   
}
