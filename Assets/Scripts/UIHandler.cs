using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

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
        highScoreText.text = tempInst._playerHighName + ": " + tempInst._highScore + '\n' + "Your Score: " + tempInst._score;
        startNameField.text = tempInst._playerName;
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

    public void ExitGame()
    {
        MainManager.instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
