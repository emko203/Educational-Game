using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappynessOutsideTimer : MonoBehaviour
{
    [Header("Links")]
    [SerializeField]
    private StatHandler statHandler;

    [Header("Values")]
    [SerializeField]
    private float interval;
    [SerializeField]
    private float WetValue;
    [SerializeField]
    private float MaxAmountOfGetWets;

    private void Start()
    {
        StartCoroutine(GettingWetTimer());
    }
    
    private void GetWet()
    {
        statHandler.ChangeStat(WetValue, EnumStats.HAPPINESS);
    }

    IEnumerator GettingWetTimer()
    {
        int currentWetValue = 0;

        while (currentWetValue <= MaxAmountOfGetWets)
        {
            yield return new WaitForSeconds(interval);
            GetWet();
            currentWetValue++;
        }
    }
}
