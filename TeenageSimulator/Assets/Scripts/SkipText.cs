using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkipText : MonoBehaviour
{
    public TMP_Text nameplate;
    private TMP_Text buttonText;
    private Button button;
    public int position = 1;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TMP_Text>();
        button.onClick.AddListener(Add);
    }

    // Update is called once per frame
    void Update()
    {
        
        IntroText();
        Debug.Log(position);
    }

    void Add() 
    {
        position++;
    }

    void IntroText()
    {
        switch (position)
        {
            case 1:
                nameplate.text = "1";
                break;
            case 2:
                nameplate.text = "2";
                break;
            case 3:
                nameplate.text = "3";
                break;
            case 4:
                nameplate.text = "4";
                break;
            case 5:
                nameplate.text = "5";
                buttonText.text = "Start Peter's journey";
                break;           
        }
    }
}
