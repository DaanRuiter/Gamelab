using UnityEngine;
using System.Collections;
using Leap;

public class color : MonoBehaviour {

    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
