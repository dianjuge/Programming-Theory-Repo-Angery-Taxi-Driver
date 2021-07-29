using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        ShowBestScore();
    }

    // Update is called once per frame
    void Update()
    {
        ZeroHealthHideSliderFill();
    }

    void ZeroHealthHideSliderFill()
    {
        if (healthSlider.value == 0)
        {
            if (GameObject.Find("Fill Area"))
            {
                GameObject.Find("Fill Area").SetActive(false);
            } 
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        GameObject data = GameObject.Find("DataTransit");
        Destroy(data);
        SceneManager.LoadScene(0);
    }

    public void ShowBestScore()
    {
        bestScoreText.text = "Best Score: " + DataTransit.Instance.bestPlayerName + " $" + DataTransit.Instance.bestPlayerScore;
    }

    public void RecordBestScore()
    {
        PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if (playerController.Income > DataTransit.Instance.bestPlayerScore)
        {
            DataTransit.Instance.SetBestPlayerName();
            DataTransit.Instance.SetBestPlayerScore(playerController.Income);
            DataTransit.Instance.SavePlayerData();
        }
    }
}
