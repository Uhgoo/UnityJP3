using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscore;
    [SerializeField] private TMP_InputField input;

    public void Start()
    {
        if (Manager.Instance.highestScore != 0)
        {
            highscore.text = "Highest Score: " + Manager.Instance.highestScorePlayerName + ": " + Manager.Instance.highestScore;
        }
    }

    public void SetName()
    {
        Manager.Instance.playerName = input.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Manager.Instance.SaveGameData();
    }

    public void ExitGame()
    {
        Manager.Instance.SaveGameData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
