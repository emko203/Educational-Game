using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SchoolOut : MonoBehaviour
{
    public string sceneToLoad;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("character") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
