using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isUsCratePlaced { get; private set; } = false;  // ENCAPSULATION
    public bool isDrCratePlaced { get; private set; } = false;  // ENCAPSULATION
    public bool isFrCratePlaced { get; private set; } = false;  // ENCAPSULATION
    public bool isBnCratePlaced { get; private set; } = false;  // ENCAPSULATION

    public static GameManager instance;
    [SerializeField] TextMeshProUGUI timeText;

    private int time;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;           // Cursor locking
        Cursor.visible = false;
        StartCoroutine(TimeCount());                        // Timer starts
    }

    private void Awake()
    {
        instance = this;                                    // Creation of GameManager singleton
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCratePlaced(int crate)                   // Method is called when crate collides with corresponding pallet
    {
        switch (crate)
        {
            case 0:
                isUsCratePlaced = true;
                Debug.Log("Usual");
                break;
            case 1:
                isDrCratePlaced = true;
                Debug.Log("Drunken");
                break;
            case 2:
                isFrCratePlaced = true;
                Debug.Log("Fragile");
                break;
            case 3:
                isBnCratePlaced = true;
                Debug.Log("Bouncy");
                break;
        }
        if(isBnCratePlaced && isDrCratePlaced && isFrCratePlaced && isUsCratePlaced)    // When all crates is on their corresponding pallet - end the game
        {
            Debug.Log("All");
            MainManager.instance.SetScore(time / 10f);
            MainManager.instance.EndGame();
        }
    }

    private IEnumerator TimeCount()                                     // Timer
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            time += 1;
            timeText.text = "Time: " + time / 10 + '.' + time % 10;     // Showing passed time on screen
        }
    }
}
