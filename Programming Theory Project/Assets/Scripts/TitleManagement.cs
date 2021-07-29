using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class TitleManagement : MonoBehaviour
{
    public Text playerNameText;
    public TextMeshProUGUI bestScoreText;
    public Button start;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShowBestScore", 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataTransit.Instance.playerName = playerNameText.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif       
    }
    public void ShowBestScore()
    {
        bestScoreText.text = "Best Score: " + DataTransit.Instance.bestPlayerName + " $" + DataTransit.Instance.bestPlayerScore;
    }

}
