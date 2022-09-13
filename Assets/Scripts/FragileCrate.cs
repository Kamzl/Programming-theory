using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileCrate : CrateController         // INHERITANCE
{
    // Start is called before the first frame update
    private Vector3 startPosition;
    private Quaternion startRotation;
    void Start()
    {
        
    }

    protected override void Awake()     // POLYMORPHISM
    {
        base.Awake();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollisionEnter(Collision collision)       // POLYMORPHISM
    {
        base.OnCollisionEnter(collision);
        Debug.Log("Collision");
        if (!(collision.gameObject.CompareTag("Palett") || collision.gameObject.CompareTag("Crate") || collision.gameObject.CompareTag("Player")))      // If collided with a wall - return to the original position
        {
            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = startRotation;
            crateRb.velocity = Vector3.zero;
        }
    }
}
