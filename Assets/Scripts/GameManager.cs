using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool usCratePlaced { get; private set; } = false;
    public bool drCratePlaced { get; private set; } = false;
    public bool frCratePlaced { get; private set; } = false;
    public bool bnCratePlaced { get; private set; } = false;
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCratePlaced(int crate)
    {
        switch (crate)
        {
            case 0:
                usCratePlaced = true;
                break;
            case 1:
                drCratePlaced = true;
                break;
            case 2:
                frCratePlaced = true;
                break;
            case 3:
                bnCratePlaced = true;
                break;
        }
    }
}
