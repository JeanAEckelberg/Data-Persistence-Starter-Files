using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainUIManager : MonoBehaviour
{
    public static MainUIManager Instance;

    public string playerName;

    public int currentHighScore;
    public string highScoreHolder;

    public int[] highScores;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        loadScores();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScoreHolder;
        public SaveData() { }

        public SaveData(int highScore, string highScoreHolder)
        {
            this.highScore = highScore;
            this.highScoreHolder = highScoreHolder;
        }
    }

    public void saveScores()
    {
        SaveData data = new SaveData(currentHighScore, highScoreHolder);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (!File.Exists(path)) return;

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        currentHighScore = data.highScore;
        highScoreHolder = data.highScoreHolder;
    }
}
