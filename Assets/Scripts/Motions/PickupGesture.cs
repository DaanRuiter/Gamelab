using UnityEngine;
using System.Collections;

public class PickupGesture : MonoBehaviour {

    public float maxFingerDistance;
    public PickupTrigger palm;
    public GameObject thumb;
    public string fingerTag;

    private void Update()
    {
        if(palm != null)
        {
            Collider[] colliders = Physics.OverlapSphere(thumb.transform.position, maxFingerDistance);
            int results = 0;
            for (int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i].transform.tag == fingerTag)
                {
                    results++;
                }
            }
            if(results >= 4)
            {
                palm.GrabObject();
            }
            else
            {
                palm.ReleaseObject();
            }
        }
    }
}
