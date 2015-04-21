using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour {

    private GameObject objectInTrigger;
    private bool checkObjects = true;
/*
    private void OnTriggerEnter(Collider collider)
    {
        if (checkObjects)
        {
            if(collider.tag == "Player")
                objectInTrigger = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject == objectInTrigger)
        {
            //objectInTrigger = null;
            Debug.Log("Ball left trigger");
        }
    }
*/
    private void OnDrawGizmos()
    {
        Color c = Color.green;
        c.a = 0.5f;
        Gizmos.color = c;
        Gizmos.DrawSphere(this.transform.position, 1);
    }
    private void Update()
    {
        if (checkObjects)
        {
            Collider[] cols = Physics.OverlapSphere(this.transform.position, 1);
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
        Debug.Log(objectInTrigger);
        if (objectInTrigger != null)
        {
            GetComponent<HingeJoint>().connectedBody = objectInTrigger.GetComponent<Rigidbody>();
            Debug.Log(GetComponent<HingeJoint>().connectedBody);
            checkObjects = false;
        }
    }

    public void ReleaseObject()
    {
        if (objectInTrigger != null)
        {
            GetComponent<HingeJoint>().connectedBody = null;
            Debug.Log("released");
            checkObjects = true;
        }
    }
}
