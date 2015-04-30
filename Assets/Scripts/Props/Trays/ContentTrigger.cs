﻿using UnityEngine;
using System.Collections;

public class ContentTrigger : MonoBehaviour {

    private Tray _tray;

    public void Init(Tray tray)
    {
        _tray = tray;
    }

    public void OnParticleCollision(GameObject particleSystem)
    {
        if(particleSystem.transform.tag == "Food")
        {
            _tray.OnFoodCollection();
        }
    }
}
