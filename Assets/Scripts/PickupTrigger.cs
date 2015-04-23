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
            foreach (Collider col in cols)
            {
                if (col.tag == "Player")
                {
                    objectInTrigger = col.gameObject;
                    break;
                }
            }
        }
    }
    public void GrabObject()
    {
        if (objectInTrigger != null)
        {
            GetComponent<HingeJoint>().connectedBody = objectInTrigger.GetComponent<Rigidbody>();
            //objectInTrigger.GetComponent<Rigidbody>().isKinematic = true;
            objectInTrigger.GetComponent<Renderer>().material.color = Color.green;
            checkObjects = false;
        }
    }

    public void ReleaseObject()
    {
        if (GetComponent<HingeJoint>().connectedBody != null)
        {
           // GetComponent<HingeJoint>().connectedBody.isKinematic = false;
            GetComponent<HingeJoint>().connectedBody.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        GetComponent<HingeJoint>().connectedBody = null;
        checkObjects = true;
    }

    public void OnDestroy()
    {
        if (GetComponent<HingeJoint>().connectedBody != null)
        {
            GetComponent<HingeJoint>().connectedBody.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
