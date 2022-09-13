using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isUsCratePlaced { get; private set; } = false;
    public bool isDrCratePlaced { get; private set; } = false;
    public bool isFrCratePlaced { get; private set; } = false;
    public bool isBnCratePlaced { get; private set; } = false;

    public static GameManager instance;
    [SerializeField] UISceneHandler sceneHandler;

    private int time;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(TimeCount());
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCratePlaced(int crate)
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
        if(isBnCratePlaced && isDrCratePlaced && isFrCratePlaced && isUsCratePlaced)
        {
            Debug.Log("All");
            MainManager.instance.SetScore(time / 10f);
            MainManager.instance.EndGame();
        }
    }

    private IEnumerator TimeCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            time += 1;
            sceneHandler.SetTimeOnScreen(time);
        }
    }
}
