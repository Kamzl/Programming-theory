using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Selecter : MonoBehaviour
{
    private CrateController crate;
    private CrateController grabbedCrate;
    private Mouse mouse;

    [SerializeField] float grabRange = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame)           // Checks for mouse click
        {
            if(crate != null && grabbedCrate == null)       // If looking at a crate and doesn't have any crate grabbed - grab the crate
            {
                crate.Grab(transform);
                grabbedCrate = crate;
            }
            else if(grabbedCrate != null)                   // Throwing an already grabbed crate
            {
                grabbedCrate.Launch(transform.forward);
                grabbedCrate = null;
            }
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);       // Making a ray for future raycast
        if(Physics.Raycast(ray, out hit, grabRange) && hit.collider.CompareTag("Crate"))        // If looking at the crate
        {
            if(crate == null)       // If haven't looked at the other crate on the last frame
            {
                crate = hit.collider.GetComponent<CrateController>();
                crate.TurnOutlineOn();
            }
            else if(crate.gameObject.name != hit.collider.name)     // If looked at the other crate on the last frame
            {
                crate.TurnOutlineOff();
                crate = hit.collider.GetComponent<CrateController>();
                crate.TurnOutlineOn();
            }
        }
        else if(crate != null)      // If turned away from the crate
        {
            crate.TurnOutlineOff();
            crate = null;
        }
    }
}
