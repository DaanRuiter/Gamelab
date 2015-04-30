using UnityEngine;
using System.Collections;

public class PlayButton : Button {
	private Menu _menu;
	void Awake()
	{
		_menu = GameObject.FindGameObjectWithTag(Tags.Menu).GetComponent<Menu>();
	}

	protected override void PressButton ()
	{
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
