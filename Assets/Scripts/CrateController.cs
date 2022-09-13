using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour    // Parent script for all of the crate behavior scripts. Allows crates to be chosen by looking at them, picked up and thrown
{
    private Outline outline;
    protected Rigidbody crateRb;
    [SerializeField] int crateType;             // 0 - usual crate, 1 - drunken crate, 2 - fragile crate, 3 - bouncy crate

    [SerializeField] float force = 400.0f;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        outline = GetComponent<Outline>();
        crateRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOutlineOn()
    {
        outline.enabled = true;
    }

    public void TurnOutlineOff()
    {
        outline.enabled = false;
    }

    public void Grab(Transform parent)                                  // Method which allows player to grab and carry crates
    {
        gameObject.layer = 8;                                           // Turn collisions with player off
        crateRb.isKinematic = true;                                     // Turn of physics
        transform.parent = parent.transform;                            // Set crate position static relative to the player
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = new Vector3(-0.35f, -0.875f, 0.45f);  // Set crate position approximately into player's hands
    }

    public void Launch(Vector3 dir)                                     // This method is called on left mouse button click when player carries a crate
    {
        transform.parent = null;
        crateRb.isKinematic = false;
        crateRb.AddForce(dir * force);
        StartCoroutine(ChangeLayer());
    }

    private IEnumerator ChangeLayer()                                   // Turn collisions with player on again
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.layer = 0;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        PalletType palletType = collision.gameObject.GetComponent<PalletType>();
        if (palletType != null && palletType.type == crateType)      // Checks if crate was been placed onto an corresponding pallet
        {
            crateRb.velocity = Vector3.zero;
            GameManager.instance.SetCratePlaced(crateType);                         // Tell Game Manager that crate was been placed
        }
    }
}
