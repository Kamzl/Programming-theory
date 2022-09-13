using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    private string playerName;
    public string _playerName
    {
        get
        {
            return playerName == null ? "Your time" : playerName;
        }
        private set => playerName = value;
    }
    private float score;
    public float _score
    {
        get
        {
            return score >= 999999 ? 0 : score;
        }
        private set => score = value;
    }
    private string playerHighName;
    public string _playerHighName
    {
        get
        {
            return playerHighName == null ? "Best time" : playerHighName;
        }
        private set => playerHighName = value;
    }
    private float highScore;
    public float _highScore
    {
        get
        {
            return highScore >= 999999 ? 0 : highScore;
        }
        private set => highScore = value;
    }

    [SerializeField] UIHandler uiHandler;

    public static MainManager instance;
    // Start is called before the first frame update
    void Start()
    {
        score = 999999;
        highScore = 999999;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        uiHandler.BeginWork();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }
    public void SetScore(float score)
    {
        Debug.Log("Saved score: " + this.score);
        Debug.Log("Our score: " + score);
        Debug.Log("High score: " + highScore);
        this.score = score;
        if(score < highScore)
        {
            highScore = score;
            playerHighName = playerName;
        }
        Debug.Log("Saved score: " + this.score);
        Debug.Log("High score: " + highScore);
    }
    [SerializeField]
    class SaveInfo
    {
        string playerLastName;
        string playerScoreName;
        int playerScore;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
