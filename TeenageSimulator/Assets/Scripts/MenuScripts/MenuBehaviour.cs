using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public void LoadScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
