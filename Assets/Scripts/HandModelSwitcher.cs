using UnityEngine;
using System.Collections;

public class HandModelSwitcher : MonoBehaviour {

    public HandModel[] handModels;
    public HandModel standardHand;

    private int currentHand = 0;
    private HandController _controller;

    private void Start()
    {
        _controller = GetComponent<HandController>();
        _controller.rightGraphicsModel = standardHand;
        _controller.leftGraphicsModel = standardHand;
    }

    public void SwitchModel()
    {
        Debug.Log("Switching Model");
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
    }
}
