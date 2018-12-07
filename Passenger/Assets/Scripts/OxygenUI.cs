using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OxygenUI : MonoBehaviour {


    public StatsHandler handler;
    private Image targetUI;


    private void Start()
    {
        //handler = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
        targetUI = GetComponent<Image>();
    }

    private void Update() {
        Oxygen();
        if(handler == null)
        {
            handler = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
        }
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
