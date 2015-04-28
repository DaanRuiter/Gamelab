using UnityEngine;
using System.Collections;

public class PlayButton : Button {
	private Menu _menu;
	void Awake()
	{
		_menu = GameObject.FindGameObjectWithTag(Tags.Menu).GetComponent<Menu>();
	}
<<<<<<< HEAD
	protected override void buttonReleased ()
	{
		//Release button
	}
	
	protected override void buttonPressed ()
	{
		Debug.Log("Button Pressed");
=======
	protected override void PressButton ()
	{
>>>>>>> 42c091c9987e9a2af1e842fca8680cd1d5e30011
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
