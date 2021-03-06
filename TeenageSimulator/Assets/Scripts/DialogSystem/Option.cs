using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogOptionObject", menuName = "DialogSystem/DialogOption")]
public class Option : ScriptableObject
{
    [SerializeField]
    private string text;
    [SerializeField]
    private Dialog linkedDialog;
    [SerializeField]
    private List<StatChange> changes;

    public Dialog LinkedDialog { get => linkedDialog; set => linkedDialog = value; }
    public string Text { get => text; set => text = value; }
    [Serializable]
    private class StatChange
    {
        [SerializeField]
        private EnumStats Stat;
        [SerializeField]
        private int ChangeAmount;
        public StatChange(EnumStats targetStat, int amount)
        {
            Stat = targetStat;
            ChangeAmount = amount;
        }
    }
}