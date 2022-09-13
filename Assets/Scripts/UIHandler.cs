using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField startNameField;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject startCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if(MainManager.instance == null)
        {
            return;
        }
        MainManager tempInst = MainManager.instance;
        highScoreText.text = tempInst._playerHighName + ": " + tempInst._highScore + '\n' + tempInst._playerName + ": " + tempInst._score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginWork()
    {
        Awake();
    }

    public void StartGame()
    {
        MainManager.instance.SetPlayerName(startNameField.text);
        MainManager.instance.StartGame();
    }
}
