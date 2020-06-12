﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerComponent : MonoBehaviour
{
    public void LoadScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }
}
