using UnityEngine;
using System.Collections;

public class PetBehavior : MonoBehaviour {
	private Mood _myMood;
	private bool _isSleeping = true;
	private bool _hasAttention = false;
	private bool _justMoved = true;
	private bool _isBeingPet = false;
	private Transform _foodBowl;
	private Transform _node;
	private float _waitingTime;
	private float _walkRange;
	private float _waitingCooldown;
	private float _attentionSpan;
	private float _attentionTime;
	private float _rotationSpeed;
	private float _speed;
	private Animator _petAnimator;
	private Animator _faceAnimator;
	private string  _oldFaceAnimation;

	public Transform[] allNodes = new Transform[0];
	void Awake()
	{
		_myMood = GetComponent<Mood>();
		//_faceAnimator = petFace.GetComponent<Animator>();
		_petAnimator = GetComponent<Animator>();
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
				_hasAttention = true;
				if(Vector3.Distance(this.transform.position,_foodBowl.position) >= _walkRange)
				{
					MoveTowards(_foodBowl);
				}
				else
				{
					EatFood();
				}
			}
			//else if(_petAnimator.GetBool("Eating"))
			//{
			//	_petAnimator.SetBool("Eating", false);
			//	_faceAnimator.SetBool("Eating", false);
			//}
		}
	}
	public void SetFaceAnimator(bool isBool,string animName,bool boolean)
	{
		_faceAnimator.SetBool(_oldFaceAnimation, false);
		if(isBool)
		{
			_faceAnimator.SetBool(animName, boolean);
			_oldFaceAnimation = animName;
		} else
		{
			_faceAnimator.SetTrigger(animName);
		}
	}
	public void ShowFoodBowl(Transform bowlTransform)
	{
		_foodBowl = bowlTransform;
	}
	private void EatFood()
	{
		//TODO: show anim + add Mood
		//_petAnimator.SetBool("Eating", true);
		//_faceAnimator.SetBool("Eating", true);
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
		if(_node != null)
		{
			if(Vector3.Distance(this.transform.position,_node.transform.position) >= _walkRange)
			{
				_petAnimator.SetBool("Sitting", false);
				MoveTowards(_node);
				_petAnimator.SetBool("Walking", true);
			} 
			else 
			{
				if(_justMoved)
				{
					_petAnimator.SetBool("Walking",false);
					_justMoved = false;
					_waitingCooldown = Time.time + _waitingTime;
					_petAnimator.SetBool("Sitting", true);
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
	public bool isBeingPet
	{
		get{
			return _isBeingPet;
		}
		set{
			_isBeingPet = value;
			if(value == true)
			{
				_petAnimator.SetTrigger("Pet");
			}
		}
	}
}
