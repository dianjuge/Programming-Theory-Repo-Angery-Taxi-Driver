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
        GameObject.Find("Player").GetComponent<PlayerController>().ArriveCountDownText[i].text = "P" + (i + 1) + " CD" + ": " + countDownTime[i];      
        if (countDownTime[i] > 0 && !playerController.IsGameOver)
        {
            StartCoroutine(PassengerArriveCountDown(i));
        }
        else
        {
            GameObject.Find("SpawnManagement").GetComponent<EnemySpawn>().SpawnGetOffLocation(i);
        }
    }

    public void RandomTravelingTime(int i)
    {
        countDownRange = Random.Range(travelingTimeLowerLimit, travelingTimeTopLimit);
        countDownTime[i] = (int)countDownRange;
        GameObject.Find("Player").GetComponent<PlayerController>().ArriveCountDownText[i].text = "P" + (i + 1) + " CD" + ": " + countDownTime[i];
        StartCoroutine(PassengerArriveCountDown(i));
    }
}
