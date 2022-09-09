using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Selecter : MonoBehaviour
{
    public BoxCollider selecter;
    private CrateController crate;
    private CrateController grabbedCrate;
    Mouse mouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            if(crate != null && grabbedCrate == null)
            {
                crate.Grab(transform);
                grabbedCrate = crate;
            }
            else if(grabbedCrate != null)
            {
                grabbedCrate.Launch(transform.forward);
                grabbedCrate = null;
            }
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10);
        if(Physics.Raycast(ray, out hit, 10.0f) && hit.collider.CompareTag("Crate"))
        {
            if(crate == null)
            {
                Debug.Log("Enter");
                crate = hit.collider.GetComponent<CrateController>();
                crate.TurnOutlineOn();
            }
            else if(crate.gameObject.name != hit.collider.name)
            {
                crate.TurnOutlineOff();
                Debug.Log("Enter");
                crate = hit.collider.GetComponent<CrateController>();
                crate.TurnOutlineOn();
            }
        }
        else if(crate != null)
        {
            Debug.Log("Exit");
            crate.TurnOutlineOff();
            crate = null;
        }
    }
}
