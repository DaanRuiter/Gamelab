using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour {

    public float grabRange;
    private GameObject objectInTrigger;
    private bool checkObjects = true;

    private void OnDrawGizmos()
    {
        Color c = Color.green;
        c.a = 0.5f;
        Gizmos.color = c;
        Gizmos.DrawSphere(this.transform.position, grabRange);
    }
    private void Update()
    {
        if (checkObjects)
        {
            Collider[] cols = Physics.OverlapSphere(this.transform.position, grabRange);
            bool objectStillInHand = false;
            foreach (Collider col in cols)
            {
                if (col.tag == "Player")
                {
                    objectInTrigger = col.gameObject;
                    break;
                }
                //if()
            }
        }
    }
    public void GrabObject()
    {
        if (objectInTrigger != null)
        {
            GetComponent<HingeJoint>().connectedBody = objectInTrigger.GetComponent<Rigidbody>();
            objectInTrigger.transform.parent = transform;
            objectInTrigger.GetComponent<Renderer>().material.color = Color.green;
            checkObjects = false;
        }
    }

    public void ReleaseObject()
    {
        if(GetComponent<HingeJoint>())
        {
            if (GetComponent<HingeJoint>().connectedBody != null)
            {
                GetComponent<HingeJoint>().connectedBody.transform.parent = null;
                GetComponent<HingeJoint>().connectedBody.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
            GetComponent<HingeJoint>().connectedBody = null;
            checkObjects = true;
        }
    }

    public void OnDestroy()
    {
        if (objectInTrigger != null)
        {
            objectInTrigger.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public GameObject ObjectInHand
    {
        get
        {
            return null;
        }
    }
}
