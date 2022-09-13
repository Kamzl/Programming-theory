using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{
    private string playerName;
    public string _playerName
    {
        get
        {
            return playerName == null ? "Player name" : playerName;               // Happens on the first launch
        }
        private set => playerName = value;
    }
    private float score;
    public float _score
    {
        get
        {
            return score >= 999999 ? 0 : score;                                     // Happens every launch
        }
        private set => score = value;
    }
    private string playerHighName;
    public string _playerHighName
    {
        get
        {
            return playerHighName == null ? "Best time" : playerHighName;           // Happens on the first launch
        }
        private set => playerHighName = value;
    }
    private float highScore;
    public float _highScore
    {
        get
        {
            return highScore >= 999999 ? 0 : highScore;                             // Happens on the first launch
        }
        private set => highScore = value;
    }

    [SerializeField] UIHandler uiHandler;

    public static MainManager instance;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (instance != null)               // Singleton initiation
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        // Make initial scores big enough for player to never actually reach it
        score = 999999;
        highScore = 999999;

        LoadData();
        DontDestroyOnLoad(gameObject);      // Main Manager should been preserved between scenes for the usage of a player name and his score
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }
    public void SetScore(float score)       // Show player time in the menu and, if his time beats the record, save new best time and best player name
    {
        this.score = score;
        if(score < highScore)
        {
            highScore = score;
            playerHighName = playerName;
        }
    }
    [SerializeField]
    class SaveInfo          // Class that exists for between-sessions data persistence
    {
        public string playerLastName;
        public string playerHighName;
        public float playerScore;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveData()  // Between sessions data save
    {
        SaveInfo data = new SaveInfo();
        data.playerLastName = playerName;
        data.playerHighName = playerHighName;
        data.playerScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadData() // Between sessions data load
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveInfo data = JsonUtility.FromJson<SaveInfo>(json);

            playerName = data.playerLastName;
            playerHighName = data.playerHighName;
            highScore = data.playerScore;
        }
    }
}
