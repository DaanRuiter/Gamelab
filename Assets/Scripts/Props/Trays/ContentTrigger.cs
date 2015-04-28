using UnityEngine;
using System.Collections;

public class ContentTrigger : MonoBehaviour {

    private Tray _tray;

    public void Init(Tray tray)
    {
        _tray = tray;
    }

	private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == _tray.contentTag)
        {

        }
    }
}
