using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	[SerializeField]private GameObject _playButton;
	[SerializeField]private GameObject _creditsButton;
	[SerializeField]private GameObject _optionsButton;

	[SerializeField]private GameObject _creditsCanvas;
	[SerializeField]private GameObject _optionsCanvas;
	public void PlayGame()
	{
		StartCoroutine(MoveButton(_playButton));
		StartCoroutine(FadeButton(_creditsButton));
		StartCoroutine(FadeButton(_optionsButton));
	}
	public void OpenCredits()
	{

	}
	public void OpenOptions()
	{

	}
	public void BackToMenu()
	{

	}
	private IEnumerator MoveButton(GameObject button)
	{
		bool inScreen = true;
		RectTransform buttonRectTransform = button.GetComponent<RectTransform>();
		Vector3 newPos = buttonRectTransform.position;
		while(inScreen)
		{
			newPos.z += 0.1f;
			buttonRectTransform.position = newPos;
			if(newPos.z >= 5)
			{
				inScreen = false;
			}
			yield return new WaitForEndOfFrame();
		}
	}
	private IEnumerator FadeButton(GameObject button)
	{
		Image buttonImage = button.GetComponent<Image>();
		Color newColor = buttonImage.color;
		bool fading = true;
		while(fading)
		{
			newColor.a -= 0.01f;
			buttonImage.color = newColor;
			if(newColor.a <= 0)
			{
				fading = false;
			}
			yield return new WaitForEndOfFrame();
		}
	}
}
