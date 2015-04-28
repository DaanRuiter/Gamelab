using UnityEngine;
using System.Collections;

public class PlayButton : ButtonHandler {
	private Menu _menu;
	void Awake()
	{
		_menu = GameObject.FindGameObjectWithTag(Tags.Menu).GetComponent<Menu>();
	}
	protected override void buttonReleased ()
	{
		//Release button
	}
	
	protected override void buttonPressed ()
	{
		Debug.Log("Button Pressed");
		_menu.PlayGame();
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "RightFinger")
        {
            Debug.Log("click");
        }
    }
}
