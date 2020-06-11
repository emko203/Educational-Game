using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Nameplate : MonoBehaviour
{
    public TMP_Text nameplate;
    // Start is called before the first frame update
    void Start()
    {
        nameplate.text = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
