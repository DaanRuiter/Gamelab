using UnityEngine;
using System.Collections;
using Leap;

public class gesture : MonoBehaviour {

    private Controller _controller;
    private HandModelSwitcher _hands;
	
	void Start () {
        _controller = new Controller();
        _controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        _hands = GetComponent<HandModelSwitcher>();
    }

    void Update()
    {
        Frame frame = _controller.Frame();
        for (int i = 0; i < frame.Gestures().Count; i++)
        {
            if (frame.Gestures()[i].Type == Gesture.GestureType.TYPE_SWIPE)
            {
                if(frame.Gestures()[i].State == Gesture.GestureState.STATE_START)
                {
                    _hands.SwitchModel();
                }
            }
        }
    }
}
