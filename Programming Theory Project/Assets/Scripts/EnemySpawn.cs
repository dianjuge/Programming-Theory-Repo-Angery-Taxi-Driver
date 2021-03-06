using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] passengerPrefabs;
    public GameObject[] getOffLocationPrefabs;
    public GameObject[] foodPrefabs;
    public GameObject player;

    private float zPos = 40;
    private float xBound = 18.5f;
    private float startDelay = 2;
    private float passengerStartDelay = 5;
    private float foodStartDelay = 10;
    private float spawnRate = 0;

    float rightSideLeftBound = 21.0f;
    float rightSideRightBound = 24.0f;
    float leftSideLeftBound = -24.0f;
    float leftSideRightBound = -21.0f;
    float xRangePassenger;

    float xGetOffLocation = 22.44f;
    float xGetOffLocationPos;
    float zGetOffLocationRange;

    private float zFoodTopBound = 29;
    private float zFoodLowerBound = -2.5f;
    private float xFoodBound = 18.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, spawnRate);
        InvokeRepeating("SpawnPassengers", passengerStartDelay, spawnRate);
        InvokeRepeating("SpawnFoods", foodStartDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemies()
    {
        if (!player.GetComponent<PlayerController>().IsGameOver)
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            float xRange = Random.Range(-xBound, xBound);
            Vector3 spawnPos = new Vector3(xRange, 0, zPos);
            Instantiate(enemyPrefabs[index], spawnPos, enemyPrefabs[index].transform.rotation);
            InvokeRepeating("SpawnEnemies", startDelay, spawnRate);
        }
    }
    void SpawnFoods()
    {
        if (!player.GetComponent<PlayerController>().IsGameOver)
        {
            int index = Random.Range(0, foodPrefabs.Length);
            float xFoodRange = Random.Range(-xFoodBound, xFoodBound);
            float zFoodRange = Random.Range(zFoodLowerBound, zFoodTopBound);
            Vector3 spawnPos = new Vector3(xFoodRange, 0, zFoodRange);
            Instantiate(foodPrefabs[index], spawnPos, foodPrefabs[index].transform.rotation);
            InvokeRepeating("SpawnFoods", foodStartDelay, spawnRate);
        }
    }
    void SpawnPassengers()
    {
        if (!player.GetComponent<PlayerController>().IsGameOver)
        {
            int index = Random.Range(0, passengerPrefabs.Length);
            int xDirection = Random.Range(0, 2);

            if (xDirection == 1)
            {
                xRangePassenger = Random.Range(rightSideLeftBound, rightSideRightBound);
            }
            else if (xDirection == 0)
            {
                xRangePassenger = Random.Range(leftSideLeftBound, leftSideRightBound);
            }
            Vector3 spawnPos = new Vector3(xRangePassenger, 0, zPos);
            Instantiate(passengerPrefabs[index], spawnPos, passengerPrefabs[index].transform.rotation);
            InvokeRepeating("SpawnPassengers", passengerStartDelay, spawnRate);
        }
    }

    public void SpawnGetOffLocation(int i)
    {
        int index = Random.Range(0, getOffLocationPrefabs.Length);
        int xDirection = Random.Range(0, 2);

        if (xDirection == 1)
        {
            xGetOffLocationPos = xGetOffLocation;
        }
        else if (xDirection == 0)
        {
            xGetOffLocationPos = -xGetOffLocation;
        }
        zGetOffLocationRange = Random.Range(-3.0f, 29.0f);
        Vector3 spawnPos = new Vector3(xGetOffLocationPos, 0, zGetOffLocationRange);
        Instantiate(getOffLocationPrefabs[index], spawnPos, getOffLocationPrefabs[index].transform.rotation);
        FindObjectOfType<Location>().GetPassengerID(i);
    }
}
