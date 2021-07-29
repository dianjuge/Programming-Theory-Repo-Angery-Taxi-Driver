using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataTransit : MonoBehaviour
{
    public static DataTransit Instance { get; private set; }
    public static float SpeedTransit { get; private set; }

    public string playerName;
    public string bestPlayerName;
    public float bestPlayerScore;
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

        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerName);
        Debug.Log(bestPlayerName);
        Debug.Log(bestPlayerScore);
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

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string bestPlayerName;
        public float bestPlayerScore;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
    }
    public void SetBestPlayerName()
    {
        bestPlayerName = playerName;
    }

    public void SetBestPlayerScore(float score)
    {
        bestPlayerScore = score;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.bestPlayerScore = bestPlayerScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestPlayerScore = data.bestPlayerScore;
        }
        
    }
}
