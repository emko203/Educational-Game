using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanging : MonoBehaviour
{
    public Text textToChange;

    [SerializeField]
    private StatHolderObject statHolder;

    private float treshHoldHappiness = 4;
    private float treshHoldBullyLevel = 4;



    public void CalculateStats() 
    {
        float happiness = statHolder.Happiness;
        float bullyLevel = statHolder.BullyLevel;

        bool happinessHigher = false;
        bool bullyHigher=false;

        if (happiness > treshHoldHappiness)
        {
            happinessHigher = true;
        }
        if (bullyLevel > treshHoldBullyLevel)
        {
           bullyHigher = true;
        }
        SetText(happinessHigher, bullyHigher);

    }

    private void SetText(bool happyHigh, bool bullyHigh) 
    {
        if (happyHigh && !bullyHigh)
        {
            MaxHMinB();
        }
        else if (!happyHigh && bullyHigh)
        {
            MinHMaxB();
        }
        else if (happyHigh && bullyHigh)
        {
            MaxHMaxB();
        }
        else if (!happyHigh && !bullyHigh)
        {
            MinHMinB();
        }
        else 
        {
            textToChange.text = "Could not calculate overall Happiness";
        }
    }

    private void MaxHMaxB() 
    {
        textToChange.text = "Based on the choices made, Peter ended up being very happy";
    }

    private void MinHMinB()
    {
        textToChange.text = "Based on the choices made, Peter ended up being very happy";
    }
    private void MaxHMinB() 
    {

        textToChange.text = "Based on the choices made, Peter ended up being very happy";      
    }

    private void MedHMedB() 
    {
        textToChange.text = "Based on the choices made, Peter ended up having decent relationships with his class mates";
    }

    private void MinHMaxB() 
    {
        textToChange.text = "Based on the choices made, Peter ended up being bullied by his classmates";
    }
}
