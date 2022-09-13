using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkenCrate : CrateController         // INHERITANCE
{
    private Vector3 drunkOffset;
    [SerializeField] float drunkSpeed = 0.005f;
    private bool isDrunk = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null && !isDrunk)        // If grabbed by a player
        {
            isDrunk = true;
            BeDrunk();
            StartCoroutine(DrunkOffsetCalculation());
        }
        else if(transform.parent == null && isDrunk)    // If being thrown by a player
        {
            StarterAssets.FirstPersonController.instance.playerMoveOffset = Vector3.zero;       // Stop being drunk
            isDrunk = false;
        }
    }

    private IEnumerator DrunkOffsetCalculation()        // Go to a random direction which is changed every second
    {
        while (transform.parent != null)
        {
            yield return new WaitForSeconds(1);
            if (isDrunk)
            {
                BeDrunk();
            }
        }
    }

    private void BeDrunk()      // ABSTRACTION
    {
        drunkOffset = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));         // Calculation of a random direction to go
        StarterAssets.FirstPersonController.instance.playerMoveOffset = drunkOffset * drunkSpeed;   // and applying it to the movement script
    }
}
