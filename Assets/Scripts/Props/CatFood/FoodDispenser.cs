using UnityEngine;
using System.Collections;

public class FoodDispenser : MonoBehaviour
{
    public LayerMask groundLayerMask;

    private Ray _ray;
    private ParticleSystem _foodDispenser;

    private void Start()
    {
        _ray = new Ray(transform.position, transform.forward);
        _foodDispenser = GetComponent<ParticleSystem>();
        _foodDispenser.enableEmission = false;
    }

    private void Update()
    {
        _ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 3, Color.cyan);
        if (Physics.Raycast(_ray, out hit, 150, groundLayerMask))
        {
            if(hit.transform.tag == "Ground")
            {
                _foodDispenser.enableEmission = true;
            }
            else
            {
                _foodDispenser.enableEmission = false;
            }
        }
        else
        {
            _foodDispenser.enableEmission = false;
        }
    }
}
