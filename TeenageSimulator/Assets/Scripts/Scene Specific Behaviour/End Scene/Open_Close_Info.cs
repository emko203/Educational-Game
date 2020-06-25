using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Close_Info : MonoBehaviour
{
    public GameObject Panel;
    public void OpenPanel() 
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }

}
