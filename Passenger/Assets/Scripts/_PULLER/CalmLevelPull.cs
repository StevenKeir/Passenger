using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CalmLevelPull : MonoBehaviour {
    StatsHandler mySH;
    //Name of the variable to pull from fungus as a string. case sensitive.
    string varNameToPull = "CalmLevels";
    //empty int value to pull. should be 0.
    public int calmLevel;
    //reference to the Fungus puller script.
    FungusPushPull myFungusPull;

    List<GameObject> myFlowcharts = new List<GameObject>();

    private void Start() {
        mySH = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
        myFungusPull = GameObject.FindGameObjectWithTag("FungusPull").GetComponent<FungusPushPull>();
        GameObject[] myFlowchartObj = GameObject.FindGameObjectsWithTag("Flowchart");
        for (int i = 0; i < myFlowchartObj.Length; i++) {
            myFlowcharts.Add(myFlowchartObj[i]);
        }
    }

    private void Update() {
            calmLevel = myFungusPull.PullInt(varNameToPull, calmLevel);
        if (mySH.calmLevel != calmLevel) {
            mySH.calmLevel = calmLevel;
        }
    }
}