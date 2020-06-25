using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class WalkingSoundManager : MonoBehaviour
{
    private static AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void PlayWalkingSound()
    {
        if (source != null)
        {
            if (SceneManager.GetActiveScene().name != "SchoolOutdoor")
            {
                if (!source.isPlaying)
                {
                    source.Play();
                }
            }
        }
    }

    public static void StopWalkingSound()
    {
        if (source != null)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }
    }
}
