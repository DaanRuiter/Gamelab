using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	protected virtual void PressButton()
	{

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == Tags.RightFinger)
		{
			PressButton();
		}
	}
}
