﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatHandler : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private int happinessStart;
    [SerializeField]
    private int bullyLevelStart;
    [SerializeField]
    private int happinessMax;
    [SerializeField]
    private int bullyLevelMax;

    [Header("Sliders")]
    [SerializeField]
    private Slider happinessSlider;
    [SerializeField]
    private Gradient happinessGradient;
    [SerializeField]
    private Slider bullyLevelSlider;
    [SerializeField]
    private Gradient bullyLevelGradient;

    private int happiness;
    private int bullyLevel;

    private void Start()
    {
        Debug.Log("Start");
        happiness = happinessStart;
        bullyLevel = bullyLevelStart;

        bullyLevelSlider.maxValue = bullyLevelMax;
        happinessSlider.maxValue = happinessMax;

        UpdateStatGrapic(EnumStats.BULLY_LEVEL, bullyLevel);
        UpdateStatGrapic(EnumStats.HAPPINESS, happiness);
    }

    private void UpdateStatGrapic(EnumStats statToChange, int value)
    {
        Slider toUpdate = GetSlider(statToChange);

        toUpdate.value = value;

        SetSliderFill(statToChange);
    }

    public void ChangeStat(int value, EnumStats statToChange)
    {
        switch (statToChange)
        {
            case EnumStats.HAPPINESS:
                happiness = AddaptValue(value, happiness, happinessMax, 0, statToChange);
                UpdateStatGrapic(EnumStats.HAPPINESS, happiness);
                break;
            case EnumStats.BULLY_LEVEL:
                bullyLevel = AddaptValue(value, bullyLevel, bullyLevelMax, 0, statToChange);
                UpdateStatGrapic(EnumStats.BULLY_LEVEL, bullyLevel);
                break;
            default:
                break;
        }
    }

    private int AddaptValue(int value, int ChangedValue, int MaxValue, int MinValue, EnumStats statToChange)
    {
        ChangedValue += value;
        if(ChangedValue > MaxValue)
        {
            ChangedValue = MaxValue;
        }
        else if(ChangedValue < MinValue)
        {
            ChangedValue = MinValue;
        }
        return ChangedValue;
    }

    private Slider GetSlider(EnumStats statToGet)
    {
        switch (statToGet)
        {
            case EnumStats.HAPPINESS:
                return happinessSlider;
            case EnumStats.BULLY_LEVEL:
                return bullyLevelSlider;
            default:
                return null;
        }
    }

    private Gradient GetGradient(EnumStats statToGet)
    {
        switch (statToGet)
        {
            case EnumStats.HAPPINESS:
                return happinessGradient;
            case EnumStats.BULLY_LEVEL:
                return bullyLevelGradient;
            default:
                return null;
        }
    }

    private void SetSliderFill(EnumStats targetStat)
    {
        Image targetImage = GetSlider(targetStat).fillRect.gameObject.GetComponent<Image>();
        targetImage.color = GetGradient(targetStat).Evaluate(GetSlider(targetStat).value);
    }
}
