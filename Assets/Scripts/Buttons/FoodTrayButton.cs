using UnityEngine;
using System.Collections;

public class FoodTrayButton : Button {
	public GameObject foodTray;
	public Transform spawnPoint;
	private GameObject _currentFoodTray;
	void Start()
	{
		_currentFoodTray = null;
	}
	protected override void PressButton ()
	{
		CreateFoodTray();
	}
	private void CreateFoodTray()
	{
		if(_currentFoodTray != null)
		{
			PropList.allProps.Remove(_currentFoodTray);
			Destroy(_currentFoodTray.gameObject);
		}

		GameObject newFoodTray = Instantiate(foodTray,spawnPoint.position,spawnPoint.rotation) as GameObject;
		_currentFoodTray = newFoodTray;
		PropList.allProps.Add(_currentFoodTray.gameObject);
	}
}
