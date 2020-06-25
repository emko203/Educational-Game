using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_To_Main_Menu : MonoBehaviour
{
    public void BackToMenu(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
