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
        MakeCursorVisible();
        SetUIText();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        MainManager.instance.SetPlayerName(startNameField.text);        // Pass current player name from the input field to the Main Manager
        MainManager.instance.StartGame();
    }

    private void MakeCursorVisible()        // ABSTRACTION
    {
        Cursor.lockState = CursorLockMode.Confined;     // Make mouse cursor visible after an FPS scene
        Cursor.visible = true;
    }

    private void SetUIText()                // ABSTRACTION
    {
        MainManager tempInst = MainManager.instance;
        highScoreText.text = tempInst._playerHighName + ": " + tempInst._highScore + '\n' + "Your Time: " + tempInst._score;       // Score field text
        startNameField.text = tempInst._playerName;         // Make the last chosen player name pre-written in the input field
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
