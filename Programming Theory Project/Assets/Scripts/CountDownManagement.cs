using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownManagement : MonoBehaviour
{
    private PlayerController playerController;

    private float countDownRange;
    private float[] countDownTime = new float[4];
    private float travelingTimeTopLimit = 5.0f;
    private float travelingTimeLowerLimit = 10.0f;

    public GameObject[] yellowSignals;
    public GameObject[] greenSignals;
    public GameObject[] redSignals;
    public int PassengerNumer { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PassengerArriveCountDown(int i)
    {
        yield return new WaitForSeconds(1);
        countDownTime[i]--;
        GameObject.Find("Player").GetComponent<PlayerController>().ArriveCountDownText[i].text = "P" + (i + 1) + "  " + countDownTime[i] + "    On the Way";      
        if (countDownTime[i] > 0 && !playerController.IsGameOver)
        {
            StartCoroutine(PassengerArriveCountDown(i));
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerController>().ArriveCountDownText[i].text = "P" + (i + 1) + "  " + countDownTime[i] + "    Let Them Out";
            ChangeSinalColorsToYellow(i);
            GameObject.Find("SpawnManagement").GetComponent<EnemySpawn>().SpawnGetOffLocation(i);
        }
    }

    public void RandomTravelingTime(int i)
    {
        ChangeSinalColorsToRed(i);
        countDownRange = Random.Range(travelingTimeLowerLimit, travelingTimeTopLimit);
        countDownTime[i] = (int)countDownRange;
        GameObject.Find("Player").GetComponent<PlayerController>().ArriveCountDownText[i].text = "P" + (i + 1) + "  " + countDownTime[i] + "    On the Way";
        StartCoroutine(PassengerArriveCountDown(i));
    }

    public void ChangeSinalColorsToGreen(int i)
    {
        redSignals[i].SetActive(false);
        yellowSignals[i].SetActive(false);
        greenSignals[i].SetActive(true);
    }

    private void ChangeSinalColorsToYellow(int i)
    {
        redSignals[i].SetActive(false);
        yellowSignals[i].SetActive(true);
        greenSignals[i].SetActive(false);
    }
    private void ChangeSinalColorsToRed(int i)
    {
        redSignals[i].SetActive(true);
        yellowSignals[i].SetActive(false);
        greenSignals[i].SetActive(false);
    }
}
