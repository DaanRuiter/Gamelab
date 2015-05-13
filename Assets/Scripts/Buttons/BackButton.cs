using UnityEngine;
using System.Collections;

public class BackButton : Button {
	private Menu _menu;
	void Awake()
	{
		_menu = GameObject.FindGameObjectWithTag(Tags.Menu).GetComponent<Menu>();
	}
	protected override void PressButton ()
	{
		//_menu.BackToMenu();
	}
}
