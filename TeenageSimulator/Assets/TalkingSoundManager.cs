using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkingSoundManager : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField]
    private List<AudioClip> lstTalkingSounds = new List<AudioClip>();
    [SerializeField]
    private AudioSource source;

    public void PlayRandomClip()
    {
        if (SceneManager.GetActiveScene().name != "SchoolOutdoor")
        {
            //if source is not playing a sound currently we load in a sound
            if (!source.isPlaying)
            {
                source.clip = lstTalkingSounds[Random.Range(0, lstTalkingSounds.Count)];
                source.Play();
            }
        }
    }
}
