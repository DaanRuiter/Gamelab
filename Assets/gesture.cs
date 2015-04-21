using UnityEngine;
using System.Collections;
using Leap;

public class gesture : MonoBehaviour {

    Controller controller;
	
	void Start () {
        controller = new Controller();
        controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
    }

    void Update()
    {
        Frame frame = controller.Frame();
        for (int i = 0; i < frame.Gestures().Count; i++)
        {
            if (frame.Gestures()[i].Type == Gesture.GestureType.TYPE_SWIPE)
            {
                if(frame.Gestures()[i].State == Gesture.GestureState.STATE_START)
                {
                    Debug.Log("Start Swipe");
                }
            }
        }
    }
}
