using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Nameplate : MonoBehaviour
{
    [SerializeField]
    private string teacherNameTag;
    private TMP_Text nameplate;
    // Start is called before the first frame update
    void Start()
    {
        nameplate = GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
        nameplate.text = teacherNameTag;
    }
}
