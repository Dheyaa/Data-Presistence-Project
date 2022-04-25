using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadMyData();
    }

    public void checkForHighScore(int inputScore)
    {
        if(inputScore > bestScore)
        {
            bestScore = inputScore;
            bestPlayerName = playerName;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveMyData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadMyData()
    {
        string filePath = Application.persistentDataPath + "/saveFile.json";
        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            bestScore = data.bestScore;
            bestPlayerName = data.bestPlayerName;
        }
    }


    // Start is called before the first frame update void Start(){} // Update is called once per frame void Update(){}
}
