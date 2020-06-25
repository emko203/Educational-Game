using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    [Header("Links")]
    [SerializeField]
    private Text QuestBoxText;

    [Header("Scene names")]
    [SerializeField]
    private string SchoolOutdoorSceneName;
    [SerializeField]
    private string SchoolInsideSceneName;

    [Header("Quest text")]
    [SerializeField]
    [TextArea()]
    private string OutsideQuestText;

    [SerializeField]
    [TextArea()]
    private string InsideQuestText;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == SchoolOutdoorSceneName)
        {
            QuestBoxText.text = OutsideQuestText;
        }
        else if (currentScene.name == SchoolInsideSceneName)
        {
            QuestBoxText.text = InsideQuestText;
        }
    }
}
