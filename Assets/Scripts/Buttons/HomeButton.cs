using UnityEngine;
using System.Collections;

public class HomeButton : Button {
	public GameObject menu;
	protected override void PressButton ()
	{
		foreach(GameObject prop in PropList.allProps)
		{
			Destroy(prop.gameObject);
			PropList.allProps.Remove(prop);
		}
		menu.SetActive(true);
		GameObject currentPet = GameObject.FindGameObjectWithTag(Tags.Pet);
		currentPet.GetComponent<PetBehavior>().isSleeping = true;
	}
}
