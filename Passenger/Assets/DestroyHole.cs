using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DestroyHole : MonoBehaviour {

    bool needsPull = true;
    //Name of the variable to pull from fungus as a string. case sensitive.
    string varNameToPull = "GotTape";
    bool gotTape;
    //reference to the Fungus puller script.
    FungusPushPull myFungusPull;

    //Disables the collider if the pulled bool is false and this is true;
    bool disableColliderOnFalse = true;

    //Disables the collider if the pulled bool is true and this is true;
    bool disableColliderOnTrue = false;

    //Disables the collider if the pulled int is 0 and this is true;
     bool disableColliderOn0 = false;

    //Disables the collider if the pulled int is !=0 and this is true;
    bool disableColliderOnBigger = false;

    //whether or not to pull the int variable in fungus named varNameToPull
    bool pullInt = false;

    //whether or not to pull the bool variable in fungus named varNameToPull
    bool pullBool = true;

    //the name of the Flowchart that holds the bool or int to push
    string myFlowchartName = "LawyerS3";
    //the name of the variable to push
    string myVarName = "PatchHole";

    //push bool to fungus
    bool pushBool = true;

    //push int to fungus
    bool pushInt = false;

    int varInt = 0;
    bool varBool = true;
    Collider myCol;

    [Header("Pulled variables DO NOT TOUCH")]
    //empty int value to pull. should be 0.
    int pulledInt;
    //empty bool value to pull. should be false.
    public bool pulledBool;

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
        if (needsPull) {
            if (pullBool) {
                pulledBool = myFungusPull.PullBool(varNameToPull, pulledBool);
            }
            if (pullInt) {
                pulledInt = myFungusPull.PullInt(varNameToPull, pulledInt);
            }
            ColliderChange();
        }
    }

    void ColliderChange() {
        if ((disableColliderOnFalse && !pulledBool) ||
            (disableColliderOnTrue && pulledBool) ||
            (disableColliderOn0 && pulledInt == 0) ||
            (disableColliderOnBigger && pulledInt > 0)) {
            myCol.enabled = false;
        }
        else {
            myCol.enabled = true;
        }
    }
    private void OnMouseDown() {
        if (pulledBool) {
            Destroy(gameObject);
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
