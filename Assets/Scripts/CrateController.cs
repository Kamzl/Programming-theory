using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    private Outline outline;
    protected Rigidbody crateRb;
    [SerializeField] int crateType;             //0 - usual crate, 1 - drunken crate, 2 - fragile crate, 3 - bouncy crate

    [SerializeField] string targetPallet;


    [SerializeField] float force = 400.0f;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        Debug.Log(gameObject.name);
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

    public void Grab(Transform parent)
    {
        gameObject.layer = 8;
        crateRb.isKinematic = true;
        transform.parent = parent.transform;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = new Vector3(-0.35f, -0.875f, 0.45f);
    }

    public void Launch(Vector3 dir)
    {
        transform.parent = null;
        crateRb.isKinematic = false;
        crateRb.AddForce(dir * force);
        StartCoroutine(ChangeLayer());
    }

    private IEnumerator ChangeLayer()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.layer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == targetPallet)
        {
            crateRb.velocity = Vector3.zero;
            GameManager.instance.setCratePlaced(crateType);
        }
    }
}
