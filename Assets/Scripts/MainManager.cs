using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    private string playerName;
    private float score;
    private string playerHighName;
    private float highScore;

    [SerializeField] Canvas startCanvas;
    [SerializeField] Canvas endCanvas;

    private bool gameStarted;
    public static MainManager instance;
    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
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
        this.score = score;
        if(score > highScore)
        {
            highScore = score;
            playerHighName = playerName;
        }
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
        gameStarted = true;
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
        startCanvas.gameObject.SetActive(false);
        endCanvas.gameObject.SetActive(true);
    }
}
