using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ChangeFungusVar : MonoBehaviour {

    public string varNameToPull;
    public int pulledInt;
    public bool pulledBool;
    FungusPushPull myFungusPull;
    [Space(5)]
    public bool disableColliderOnFalse;
    public bool disableColliderOnTrue;
    public bool disableColliderOn0;
    public bool disableColliderOnBigger;
    [Space(5)]
    public bool pullInt;
    public bool pullBool;
    [Space(15)]
    public string myFlowchartName;
    public string myVarName;
    [Space(15f)]
    [Header("Whether to use Bool or Int. only check one")]
    public bool pushBool;
    public bool pushInt;
    [Space(5f)]
    public int varInt;
    public bool varBool;
    Collider myCol;

    List<GameObject> myFlowcharts = new List<GameObject>();

    private void Start() {
        if (GetComponent<Collider>()) {
            myCol = GetComponent<Collider>();
        }
        myFungusPull = GameObject.FindGameObjectWithTag("FungusPull").GetComponent<FungusPushPull>();
        GameObject[] myFlowchartObj = GameObject.FindGameObjectsWithTag("Flowchart");
        for (int i = 0; i < myFlowchartObj.Length; i++) {
            myFlowcharts.Add(myFlowchartObj[i]);
        }
    }

    private void Update() {
        if (pullBool) {
            pulledBool = myFungusPull.PullBool(varNameToPull, pulledBool);
        }
        if (pullInt) {
            pulledInt = myFungusPull.PullInt(varNameToPull, pulledInt);
        }
        ColliderChange();
    }
    
    void ColliderChange() {
        if ((disableColliderOnFalse && !pulledBool) ||
            (disableColliderOnTrue && pulledBool) ||
            (disableColliderOn0 && pulledInt == 0)||
            (disableColliderOnBigger && pulledInt > 0)) {
            myCol.enabled = false;
        }
        else {
            myCol.enabled = true;
        }
    }

    private void OnDestroy() {
        for (int i = 0; i < myFlowcharts.Count; i++) {
            if (myFlowcharts[i].name == myFlowchartName) {
                if (pushBool) {
                    myFlowcharts[i].GetComponent<Flowchart>().SetBooleanVariable(myVarName, varBool);
                }
                if (pushInt) {
                    myFlowcharts[i].GetComponent<Flowchart>().SetIntegerVariable(myVarName, varInt);
                }
            }
        }
    }
}
