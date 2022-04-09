using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameField;
    [SerializeField] Text bestScore;

    // Start is called before the first frame update
    void Start()
    {
        GetNameAndBestScore();
    }

    public void StartNew(){
        Debug.Log("loading main...");
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        Debug.Log("exiting...");
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetPlayerName(){
        DataManager.Instance.playerName = playerNameField.text;
        DataManager.Instance.SaveName();
    }

    public void GetNameAndBestScore(){
        DataManager.SaveData data = DataManager.Instance.LoadAllData();
        playerNameField.text = data.prevPlayerName;
        bestScore.text = $"Score : {data.bestScoreName} : {data.bestScoreInt}";

        DataManager.Instance.playerName = data.prevPlayerName;
        DataManager.Instance.bestScoreName = data.bestScoreName;
        DataManager.Instance.bestScoreInt = data.bestScoreInt;
    }
}
