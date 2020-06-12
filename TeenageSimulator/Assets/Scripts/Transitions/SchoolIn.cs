using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SchoolIn : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Schoolhallway");
    }
}
