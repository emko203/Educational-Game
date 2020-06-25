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
            textToChange.text = "De vrolijkheid en het pestlevel van Peter konden niet berekend worden.";
        }
    }

    private void MaxHMaxB() 
    {
        textToChange.text = "Jouw keuzes hebben Peter zeer blij gemaakt, maar Peter wordt nu wel meer gepest.";
    }

    private void MinHMinB()
    {
        textToChange.text = "Jouw keuzes hebben Peter niet heel blij gemaakt, maar Peter wordt nu wel minder gepest.";
    }
    private void MaxHMinB() 
    {

        textToChange.text = "Jouw keuzes hebben Peter zeer blij gemaakt en Peter wordt nu ook minder gepest.";      
    }

    private void MedHMedB() 
    {
        textToChange.text = "Jouw keuzes hebben Peter redelijk blij gemaakt. Hij wordt wel nog evenveel gepest als eerst.";
    }

    private void MinHMaxB() 
    {
        textToChange.text = "Jouw keuzes hebben Peter niet heel blij gemaakt. Ook wordt Peter nu meer gepest.";
    }
}
