﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStatCollection : MonoBehaviour {
    public float myOxyMult;
    public float busOxyMult;
    public GameObject myStatHandler;
    GameObject mySHobj;
    StatsHandler mySH;
    private void Start() {
        if (GameObject.FindGameObjectWithTag("StatHandler") == null) {
            mySHobj = Instantiate(myStatHandler, transform.position, Quaternion.identity);
            mySH = mySHobj.GetComponent<StatsHandler>();
            mySH.myBusMinutesMult = busOxyMult;
            mySH.myMinutesMult = myOxyMult;
            mySH.hasOxygen = true;
        }
        Destroy(gameObject);
    }
}