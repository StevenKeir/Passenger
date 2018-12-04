﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OxygenUI : MonoBehaviour {


    StatsHandler handler;
    private Image targetUI;


    private void Start()
    {
        handler = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
        targetUI = GetComponent<Image>();
    }

    private void Update() {
        Oxygen();
    }

    void Oxygen()
    {
        if (handler.outside)
        {
            targetUI.fillAmount = handler.oxygen / handler.maxOxygen;
        }
        else
        {
            targetUI.fillAmount = handler.busOxygen / handler.origBusOxygen;
        }
    }
}