using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileCrate : CrateController
{
    // Start is called before the first frame update
    private Vector3 startPosition;
    private Quaternion startRotation;
    void Start()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (!(collision.gameObject.CompareTag("Palett") || collision.gameObject.CompareTag("Crate") || collision.gameObject.CompareTag("Player")))
        {
            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = startRotation;
            crateRb.velocity = Vector3.zero;
        }
    }
}
