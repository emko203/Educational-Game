using System.Collections;
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
    private Slider bullyLevelSlider;

    private int happiness;
    private int bullyLevel;

    private void Awake()
    {
        happiness = happinessStart;
        bullyLevel = bullyLevelStart;

        bullyLevelSlider.maxValue = bullyLevelMax;
        happinessSlider.maxValue = happinessMax;
    }

    private void UpdateStatGrapic(EnumStats statToChange, int value)
    {
        Slider toUpdate = GetSlider(statToChange);

        toUpdate.value = value;
    }

    public void UpStat(int value, EnumStats statToChange)
    {
        switch (statToChange)
        {
            case EnumStats.HAPPINESS:
                happiness = AddaptValueToHigher(value, happiness, happinessMax, statToChange);
                break;
            case EnumStats.BULLY_LEVEL:
                bullyLevel = AddaptValueToHigher(value, bullyLevel, bullyLevelMax, statToChange);
                break;
            default:
                break;
        }
    }

    public void LowerStat(int value, EnumStats statToChange)
    {
        switch (statToChange)
        {
            case EnumStats.HAPPINESS:
                happiness = AddaptValueToLower(value, happiness, statToChange);
                break;
            case EnumStats.BULLY_LEVEL:
                bullyLevel = AddaptValueToLower(value, bullyLevel, statToChange);
                break;
            default:
                break;
        }
    }

    //Up the value to a higher value but never higher then the maxvalue
    private int AddaptValueToHigher(int value, int ChangedValue, int maxValue, EnumStats statToChange)
    {
        if (ChangedValue + value <= maxValue)
        {
            ChangedValue -= value;
        }
        else
        {
            ChangedValue = maxValue;
        }

        UpdateStatGrapic(statToChange,ChangedValue);

        return ChangedValue;
    }

    //Lower the value to a lower value but never lower then the 0
    private int AddaptValueToLower(int value, int ChangedValue, EnumStats statToChange)
    {
        if (ChangedValue - value >= 0)
        {
            ChangedValue -= value;
        }
        else
        {
            ChangedValue = 0;
        }

        UpdateStatGrapic(statToChange, value);

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
}
