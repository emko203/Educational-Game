using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingSoundManager : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField]
    private List<AudioClip> lstTalkingSounds = new List<AudioClip>();
    [SerializeField]
    private AudioSource source;

    public void PlayRandomClip()
    {
        //if source is not playing a sound currently we load in a sound
        if (!source.isPlaying)
        {
            source.clip = lstTalkingSounds[Random.Range(0, lstTalkingSounds.Count)];
            source.Play();
        }
    }
}
