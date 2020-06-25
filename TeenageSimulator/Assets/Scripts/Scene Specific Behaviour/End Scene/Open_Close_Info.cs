using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Close_Info : MonoBehaviour
{
    public GameObject Panel;
    public GameObject TitleH;
    private bool panelOpen = false;

    public void OpenPanel() 
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }

    public void ShowHappiness() 
    {
        OpenPanel();
        TitleH.SetActive(true);
    }

    public void ShowBully() 
    {
        OpenPanel();
        TitleH.SetActive(false);
    }
}
