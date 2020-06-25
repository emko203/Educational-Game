using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject Panel;

    public void EndGame()
    {
        Application.Quit();
    }

    public void openPanel() 
    {
        Panel.SetActive(true);
    }

    public void closePanel() 
    {
        Panel.SetActive(false);
    }
}
