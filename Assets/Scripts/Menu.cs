﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	private PetBehavior _petBehavior;

	[SerializeField]private GameObject _playButton;
	//[SerializeField]private GameObject _creditsButton;
	[SerializeField]private GameObject _optionsButton;
	[SerializeField]private GameObject _backButton;

	[SerializeField]private GameObject _menuCanvas;
	//[SerializeField]private GameObject _creditsCanvas;
	[SerializeField]private GameObject _optionsCanvas;

	/*
	private Vector3 oldPlayButtonPos;
	private Vector3 oldCreditsButtonPos;
	private Vector2 oldOptionsButtonPos;
	private Vector3 oldBackButtonPos;
	void Start()
	{
		oldPlayButtonPos = _playButton.GetComponent<RectTransform>().position;
		oldCreditsButtonPos = _creditsButton.GetComponent<RectTransform>().position;
		oldOptionsButtonPos = _optionsButton.GetComponent<RectTransform>().position;
	} */
	void Awake()
	{
		_petBehavior = GameObject.FindGameObjectWithTag(Tags.Cat).GetComponent<PetBehavior>();
	}

	public void PlayGame()
	{
		Debug.Log("Play game");

		_menuCanvas.SetActive(false);
		_petBehavior.isSleeping = false;
		//TODO: enable cat actions
	}
	/*
	public void OpenCredits()
	{
        /*StartCoroutine(MoveButton(_creditsButton));
        StartCoroutine(FadeButton(_optionsButton));
        if(StartCoroutine(FadeButton(_playButton)))
        {
            _creditsCanvas.SetActive(true);
        }
		_menuCanvas.SetActive(false);
		_creditsCanvas.SetActive(true);
	} 
	public void OpenOptions()
	{
		_menuCanvas.SetActive(false);
		_optionsCanvas.SetActive(true);
	}
     
    public void BackToMenu()
	{
		
		_menuCanvas.SetActive(true);
		//if(_creditsCanvas.activeInHierarchy)
		//	_creditsCanvas.SetActive(false);
		if(_optionsCanvas.activeInHierarchy)
			_optionsCanvas.SetActive(false);
	}
	
	private void ResetButton(GameObject button)
	{
		button.GetComponent<RectTransform>().position = oldPlayButtonPos;
		button.GetComponent<Image>().color = Color.white;
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
	} */
}
