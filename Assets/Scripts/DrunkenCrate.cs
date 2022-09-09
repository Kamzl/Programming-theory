using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkenCrate : CrateController
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
        if(transform.parent != null && !isDrunk)
        {
            isDrunk = true;
            BeDrunk();
            StartCoroutine(DrunkOffsetCalculation());
        }
        else if(transform.parent == null && isDrunk)
        {
            StarterAssets.FirstPersonController.instance.playerMoveOffset = Vector3.zero;
            Debug.Log(StarterAssets.FirstPersonController.instance.playerMoveOffset);
            isDrunk = false;
        }
    }

    private IEnumerator DrunkOffsetCalculation()
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

    private void BeDrunk()
    {
        drunkOffset = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        StarterAssets.FirstPersonController.instance.playerMoveOffset = drunkOffset * drunkSpeed;
    }
}
