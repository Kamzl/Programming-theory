using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISceneHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTimeOnScreen(int time)
    {
        timeText.text = "Time: " + time / 10 + '.' + time % 10;
    }
}
