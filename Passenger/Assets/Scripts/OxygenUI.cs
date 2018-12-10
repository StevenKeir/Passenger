using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenUI : MonoBehaviour {


    public StatsHandler HandlerScript;
    private Image targetUI;


    private void Start()
    {
        targetUI = GetComponent<Image>();
    }

    public void Update() {
 
        if (HandlerScript == null)
        {
            HandlerScript = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
        }
        Oxygen();
    }

    void Oxygen()
    {
        if (HandlerScript.outside)
        {
            targetUI.fillAmount = HandlerScript.oxygen / HandlerScript.maxOxygen;
        }
        else
        {
            targetUI.fillAmount = HandlerScript.busOxygen / HandlerScript.origBusOxygen;
        }
    }
}
