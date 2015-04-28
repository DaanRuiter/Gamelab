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
		//TODO: Disable cat actions
	}
}
