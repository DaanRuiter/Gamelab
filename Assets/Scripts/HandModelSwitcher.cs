using UnityEngine;
using System.Collections;

public class HandModelSwitcher : MonoBehaviour {

    public HandModel[] handModels;
    public HandModel standardHand;

    private int currentHand = 0;
    private HandController _controller;
    private float nextSwipe = 0f;

    private void Start()
    {
        _controller = GetComponent<HandController>();
        _controller.rightGraphicsModel = standardHand;
        _controller.leftGraphicsModel = standardHand;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            SwitchModel();
        }
    }

    public void SwitchModel()
    {
        if(nextSwipe <= Time.time)
        {
            if (currentHand < handModels.Length - 1)
            {
                currentHand++;
            }
            else
            {
                currentHand = 0;
            }
            _controller.rightGraphicsModel = handModels[currentHand];
            _controller.leftGraphicsModel = handModels[currentHand];
            nextSwipe = Time.time + 0.5f;
            _controller.DestroyAllHands();
        }
    }
}
