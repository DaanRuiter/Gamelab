using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum Moods
{
	Happy,
	Angry,
	Bored,
	Annoyed,
	Scared
}

public class Mood : MonoBehaviour {
	public float moodCooldown;
	public float awayCooldown;
	public Image moodImage;
	public Sprite[] allMoodImages = new Sprite[0];

	private PetBehavior _myBehavior;
	private Moods _currentMood;
	private bool _isDoingNothing;
	private float _moodCooldown;
	private float _happyFeeling;
	private float _boredFeeling;
	private float _angryFeeling;
	private Dictionary<Moods, float> moodAndFeeling = new Dictionary<Moods, float>();
	private Dictionary<Moods, string> moodAndAnimation = new Dictionary<Moods, string>();
	void Awake()
	{
		_myBehavior = GetComponent<PetBehavior>();
	}
	// Use this for initialization
	void Start () {
		_currentMood = Moods.Happy;
		_happyFeeling = 100;
		_boredFeeling = 0;
		_angryFeeling = 0;

		moodAndFeeling.Add(Moods.Angry, _angryFeeling);
		moodAndFeeling.Add(Moods.Happy, _happyFeeling);
		moodAndFeeling.Add(Moods.Bored, _boredFeeling);

		moodAndAnimation.Add(Moods.Angry, "isAngry");
		moodAndAnimation.Add(Moods.Bored, "isBored");
		moodAndAnimation.Add(Moods.Annoyed, "isAnnoyed");
		moodAndAnimation.Add(Moods.Happy, "isHappy");
		moodAndAnimation.Add(Moods.Scared, "isScared");
	}
	
	// Update is called once per frame
	void Update () {
		//TODO if doing nothing.
		if(_currentMood == Moods.Happy && !_myBehavior.hasAttention)
		{
			//_myBehavior.SetFaceAnimator(true,"NoAttention",true);
			if(_happyFeeling != 0)
				_happyFeeling -= 0.1f;
			if(_boredFeeling != 100)
				_boredFeeling += 0.1f;
		}
	}
	private void CheckMood(Moods moodToCheck)
	{
		bool changeMood = true;
		if(_currentMood != moodToCheck && _moodCooldown >= Time.time)
		{
			foreach(KeyValuePair<Moods, float> value in moodAndFeeling)
			{
				if(value.Key != moodToCheck && moodAndFeeling[moodToCheck] < value.Value)
				{
					changeMood = false;
					break;
				}
			}
			if(changeMood)
			{
				_currentMood = moodToCheck;
				ChangeMoodImage(_currentMood);
				_myBehavior.SetFaceAnimator(true,moodAndAnimation[_currentMood],true);
			}
		}
	}
	private void ChangeMoodImage(Moods mood)
	{
		foreach(Sprite sprite in allMoodImages)
		{
			if(sprite.name == "Mood_" + mood.ToString())
			{
				moodImage.sprite = sprite;
				break;
			}
		}
	}
	public void ChangeMood(Moods mood)
	{
		if(_moodCooldown >= Time.time)
		{
			_currentMood = mood;
			_moodCooldown = Time.time + moodCooldown;
		}
	}
	public float happyFeeling
	{
		get{
			return _happyFeeling;
		}
		set{
			_happyFeeling = value;
			CheckMood(Moods.Happy);
		}
	}
	public float boredFeeling
	{
		get{
			return _boredFeeling;
		}
		set{
			_boredFeeling = value;
			CheckMood(Moods.Bored);
		}
	}
	public float angryFeeling
	{
		get{
			return _angryFeeling;
		}
		set{
			_angryFeeling = value;
			CheckMood(Moods.Angry);
		}
	}
}
