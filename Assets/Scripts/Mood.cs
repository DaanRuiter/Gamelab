using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	private Moods _currentMood;
	private bool _isDoingNothing;
	private float _moodCooldown;
	private float _happyFeeling;
	private float _boredFeeling;
	private float _angryFeeling;
	private float _awayTimer;
	private Dictionary<Moods, float> moodAndFeeling = new Dictionary<Moods, float>();
	// Use this for initialization
	void Start () {
		_currentMood = Moods.Happy;
		_happyFeeling = 100;
		_boredFeeling = 0;
		_angryFeeling = 0;

		moodAndFeeling.Add(Moods.Angry, _angryFeeling);
		moodAndFeeling.Add(Moods.Happy, _happyFeeling);
		moodAndFeeling.Add(Moods.Bored, _boredFeeling);
	}
	
	// Update is called once per frame
	void Update () {
		//TODO if doing nothing.
		if(_currentMood == Moods.Happy && _isDoingNothing)
		{
			if(_happyFeeling != 0)
				_happyFeeling -= 0.1f;
			if(_boredFeeling != 100)
				_boredFeeling += 0.1f;
		}
		if(!_isDoingNothing && _awayTimer >= Time.time)
		{
			_isDoingNothing = true;
		}
	}
	private void CheckMood(Moods moodToCheck)
	{
		_awayTimer = Time.time + awayCooldown;
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
			}
		}
	}
	public void ChangeMood(Moods mood)
	{
		_awayTimer = Time.time + awayCooldown;
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
