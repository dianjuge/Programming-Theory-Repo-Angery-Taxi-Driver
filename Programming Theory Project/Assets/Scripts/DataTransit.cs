using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTransit : MonoBehaviour
{
    public static DataTransit Instance { get; private set; }
    public static float SpeedTransit { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SpeedTransit);
    }

    public void EasyMode()
    {
       
        SpeedTransit = 5;
    }
    public void NormalMode()
    {
        SpeedTransit = 10;
    }
    public void HardMode()
    {
        SpeedTransit = 20;
    }
}
