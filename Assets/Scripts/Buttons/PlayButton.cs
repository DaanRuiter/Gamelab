using UnityEngine;
using System.Collections;

public class PlayButton : ButtonHandler {
	private Menu _menu;
	void Awake()
	{
		_menu = GameObject.FindGameObjectWithTag(Tags.Menu).GetComponent<Menu>();
	}
	protected override void FireButtonEnd ()
	{
		//Release button
	}
	
	protected override void FireButtonStart ()
	{
		Debug.Log("Button Pressed");
		_menu.PlayGame();
	}
}
