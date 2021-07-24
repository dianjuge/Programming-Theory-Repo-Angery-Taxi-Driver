using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownManagement : MonoBehaviour
{
    public bool isArrived = false;
    private float countDownRange;
    private float countDownTime;
    private float travelingTimeTopLimit = 5.0f;
    private float travelingTimeLowerLimit = 10.0f;
    private int passengerNumber;
    public int PassengerNumer { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PassengerArriveCountDown()
    {

        GameObject.Find("Player").GetComponent<PlayerController>().ArriveCountDown.text = "P" + passengerNumber + "ArrCD" + ": " + countDownTime;
        countDownTime--;
        if (countDownTime > 0)
        {
            InvokeRepeating("PassengerArriveCountDown", 1, 0);
        }
        else if(!isArrived)
        {
            isArrived = true;
            GameObject.Find("SpawnManagement").GetComponent<EnemySpawn>().SpawnGetOffLocation();
        }
    }

    public void RandomTravelingTime()
    {
        isArrived = false;
        countDownRange = Random.Range(travelingTimeLowerLimit, travelingTimeTopLimit);
        countDownTime = (int)countDownRange;
        PassengerArriveCountDown();
    }
}
