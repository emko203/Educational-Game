using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleHelper : MonoBehaviour
{
    [SerializeField]
    List<Bubble> lstBubbles = new List<Bubble>();

    public List<Bubble> LstBubbles { get => lstBubbles; }
}
