using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [Header("Light")]
    [SerializeField]
    private Light lightningLight;
    [SerializeField]
    private float flashIntensity;

    [Header("Timing")]
    [SerializeField]
    private float maxPauseTime;
    [SerializeField]
    private float minPauseTime;
    [SerializeField]
    private float FlashTimeOut;

    [Header("Sound")]
    [SerializeField]
    private List<AudioClip> lstThunderSounds = new List<AudioClip>();
    [SerializeField]
    private AudioSource source;

    private float currentPauseTime;
    private float normalIntensity;

    private bool doLightning = false;

    private void Awake()
    {
        currentPauseTime = SetRandomPauseTime();
        normalIntensity = lightningLight.intensity;
    }

    private void Start()
    {
        doLightning = true;
        StartCoroutine(LoopLighting());
    }

    private float SetRandomPauseTime()
    {
        return Random.Range(minPauseTime, maxPauseTime);
    }

    public void StopLightning()
    {
        doLightning = false;
    }

    private void PlayThunderSound()
    {
        if (!source.isPlaying)
        {
            source.clip = lstThunderSounds[Random.Range(0, lstThunderSounds.Count)];
            source.Play();
        }
    }

    private IEnumerator LoopLighting()
    {
        while (doLightning)
        {
            yield return new WaitForSeconds(currentPauseTime);
            currentPauseTime = SetRandomPauseTime();
            lightningLight.intensity = flashIntensity;
            PlayThunderSound();
            yield return new WaitForSeconds(FlashTimeOut);
            lightningLight.intensity = normalIntensity;
        }
    }
}
