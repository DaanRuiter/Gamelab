using UnityEngine;
using System.Collections;

public class Tray : MonoBehaviour {

    public string contentTag;
    public float maxLayerHeight;
    public float layerSpeed;

    public GameObject contentTrigger;

    private float _amount;
    private GameObject _contentLayer;

    private void Start()
    {
        contentTrigger.GetComponent<ContentTrigger>().Init(this);
        _contentLayer = transform.FindChild("Content Layer").gameObject;
        _contentLayer.transform.position = Vector3.zero;
    }

    public void AddItem(Particle item)
    {

    }
}
