using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatHolder", menuName = "StatSystem")]
public class StatHolderObject : ScriptableObject
{
    [SerializeField]
    private float StartHappiness;
    [SerializeField]
    private float StartBullyLevel;

    public float Happiness;
    public float BullyLevel;

    
    private void OnEnable()
    {
        Happiness = StartHappiness;
        BullyLevel = StartBullyLevel;
    }
}
