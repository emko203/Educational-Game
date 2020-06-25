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
    [SerializeField]
    private StatHolderObject statHolder;

    [Header("Sliders")]
    [SerializeField]
    private Slider happinessSlider;
    [SerializeField]
    private Gradient happinessGradient;
    [SerializeField]
    private Slider bullyLevelSlider;
    [SerializeField]
    private Gradient bullyLevelGradient;

    private float happiness;
    private float bullyLevel;

    private void Start()
    {
        happiness = happinessStart;
        bullyLevel = bullyLevelStart;

        bullyLevelSlider.maxValue = bullyLevelMax;
        happinessSlider.maxValue = happinessMax;

        UpdateStatGrapic(EnumStats.BULLY_LEVEL, bullyLevel, bullyLevelMax);
        UpdateStatGrapic(EnumStats.HAPPINESS, happiness, happinessMax);
    }

    private void UpdateStatGrapic(EnumStats statToChange, float value, int maxValue)
    {
        Slider toUpdate = GetSlider(statToChange);

        toUpdate.value = value;
        toUpdate.GraphicUpdateComplete();

        float mappedValue = value;

        SetSliderFill(statToChange, mappedValue);
    }

    public void ChangeStat(float value, EnumStats statToChange)
    {
        switch (statToChange)
        {
            case EnumStats.HAPPINESS:
                happiness = AddaptValue(value, happiness, happinessMax, 0, statToChange);
                UpdateStatGrapic(EnumStats.HAPPINESS, happiness, happinessMax);
                statHolder.Happiness += value;
                break;
            case EnumStats.BULLY_LEVEL:
                bullyLevel = AddaptValue(value, bullyLevel, bullyLevelMax, 0, statToChange);
                UpdateStatGrapic(EnumStats.BULLY_LEVEL, bullyLevel, bullyLevelMax);
                statHolder.BullyLevel += value;
                break;
            default:
                break;
        }
    }

    private float AddaptValue(float value, float ChangedValue, int MaxValue, int MinValue, EnumStats statToChange)
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

    private void SetSliderFill(EnumStats targetStat, float value)
        {
        Slider targetSlider = GetSlider(targetStat);
        Image targetImage = targetSlider.fillRect.gameObject.GetComponent<Image>();
        targetImage.color = GetGradient(targetStat).Evaluate(value);
    }
}
