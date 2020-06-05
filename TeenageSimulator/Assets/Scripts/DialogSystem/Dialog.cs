using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogObject", menuName = "DialogSystem/Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField]
    private string text;
    [SerializeField]
    private List<Option> options;

    public string Text { get => text;}
    public List<Option> Options { get => options;}
}
