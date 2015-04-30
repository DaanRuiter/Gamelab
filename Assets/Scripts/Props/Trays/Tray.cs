using UnityEngine;
using System.Collections;

public class Tray : MonoBehaviour {

    public float maxLayerHeight;
    public float foodCapacity;

    private float _amount;
    private GameObject _contentLayer;
    private Vector3 _newLayerPos;

    private void Start()
    {
        _contentLayer = transform.FindChild("Content Layer").gameObject;
        _contentLayer.GetComponent<ContentTrigger>().Init(this);
        _newLayerPos = _contentLayer.transform.localPosition;
    }

    public void OnFoodCollection()
    {
        if(_newLayerPos.y < maxLayerHeight)
        {
            _newLayerPos.y += maxLayerHeight / foodCapacity;
            _contentLayer.transform.localPosition = _newLayerPos;
        }
    }
}
