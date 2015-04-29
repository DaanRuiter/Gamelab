using UnityEngine;
using System.Collections;

public class PetBehavior : MonoBehaviour {
	private Mood _myMood;
	private bool _isSleeping = true;
	private bool _hasAttention = false;
	private bool _justMoved = true;
	private Transform _foodBowl;
	private Transform _node;
	private float _waitingTime;
	private float _walkRange;
	private float _waitingCooldown;
	private float _attentionSpan;
	private float _attentionTime;
	private float _rotationSpeed;
	private float _speed;

	public Transform[] allNodes = new Transform[0];
	void Awake()
	{
		_myMood = GetComponent<Mood>();
	}

	// Use this for initialization
	void Start () {
		_speed = 2.5f;
		_rotationSpeed = 10;
		_waitingTime = 10;
		_attentionTime = 10;
		_attentionSpan = 0;
		_waitingCooldown = 0;
		_walkRange = 3;
		_isSleeping = false;
		_node = allNodes[Random.Range(0,allNodes.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		if(!_isSleeping)
		{
			if(!_hasAttention && _foodBowl == null)
			{
				WalkAround();
			} 
			else if(_attentionSpan >= Time.time)
			{
				_hasAttention = false;
			} 
			else if(_foodBowl != null)
			{
				if(Vector3.Distance(this.transform.position,_foodBowl.position) >= _walkRange)
				{
					MoveTowards(_foodBowl);
				}
				else
				{
					EatFood();
				}
			} 
		}
	}
	public void ShowFoodBowl(Transform bowlTransform)
	{
		_foodBowl = bowlTransform;
	}
	private void EatFood()
	{
		//TODO: show anim + add Mood
		_myMood.happyFeeling += 0.1f;
	}
	private void MoveTowards(Transform trans)
	{
		this.transform.position = Vector3.MoveTowards(this.transform.position,trans.position, _speed * Time.deltaTime);
		Vector3 relativePos = trans.position - this.transform.position;
		Quaternion lookAt = Quaternion.LookRotation(relativePos);
		this.transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, Time.deltaTime * _rotationSpeed);
	}
	private void WalkAround()
	{
		if(Vector3.Distance(this.transform.position,_node.transform.position) >= _walkRange)
		{
			MoveTowards(_node);
		} 
		else 
		{
			if(_justMoved)
			{
				_justMoved = false;
				_waitingCooldown = Time.time + _waitingTime;
				Debug.Log(_waitingCooldown);
			}
			if(_waitingCooldown <= Time.time)
			{
				Transform newNode = allNodes[Random.Range(0,allNodes.Length)];
				while(newNode == _node)
				{
					newNode = allNodes[Random.Range(0,allNodes.Length)];
				}
				_node = newNode;
				_justMoved = true;
			}
		}
	}
	public bool hasAttention
	{
		get{
			return _hasAttention;
		}
		set{
			_hasAttention = value;
			if(value == true)
			{
				_attentionSpan = Time.time + _attentionTime;
			}
		}
	}
	public bool isSleeping
	{
		get{
			return _isSleeping;
		}
		set{
			_isSleeping = value;
		}
	}
}
