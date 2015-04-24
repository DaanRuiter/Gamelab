using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
	public float triggerDistance = 0.025f;
	public float cushionThickness = 0.005f;
	
	protected float scaled_spring_;
	protected float scaled_trigger_distance_;
	protected float scaled_cushion_thickness_;
	
	protected float min_distance_;
	protected float max_distance_;
	
	protected float m_localTriggerDistance;
	protected float m_localCushionThickness;
	protected bool m_isPressed = false;
	
	protected virtual void FireButtonEnd ()
	{
		//Release button
	}
	
	protected virtual void FireButtonStart ()
	{
		//Activate button
	}

	/// <summary>
	/// Check if the button is being pressed or not
	/// </summary>
	private void CheckTrigger()
	{
		float scale = transform.lossyScale.z;
		m_localTriggerDistance = triggerDistance / scale;
		m_localCushionThickness = Mathf.Clamp(cushionThickness / scale, 0.0f, m_localTriggerDistance - 0.001f);
		if (m_isPressed == false)
		{
			if (transform.localPosition.z > m_localTriggerDistance)
			{
				m_isPressed = true;
				FireButtonStart();
			}
		}
		else if (m_isPressed == true)
		{
			if (transform.localPosition.z < (m_localTriggerDistance - m_localCushionThickness))
			{
				m_isPressed = false;
				FireButtonEnd();
			}
		}
	}
	
	protected virtual void Start()
	{
		cushionThickness = Mathf.Clamp(cushionThickness, 0.0f, triggerDistance - 0.001f);
	}
	
	protected virtual void Update()
	{
		CheckTrigger();
	}
}
