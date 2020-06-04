using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogOptionObject", menuName = "DialogSystem/DialogOption")]
public class Option : ScriptableObject
{
    [SerializeField]
    private string Text;
    [SerializeField]
    private Dialog LinkedDialog;
    [SerializeField]
    private List<StatChange> changes;

    private class StatChange
    {
        private EnumStats Stat;
        private int ChangeAmount;
        public StatChange(EnumStats targetStat, int amount)
        {
            Stat = targetStat;
            ChangeAmount = amount;
        }
    }
}