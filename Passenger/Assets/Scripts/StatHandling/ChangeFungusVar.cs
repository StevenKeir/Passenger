using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ChangeFungusVar : MonoBehaviour {

    public string myFlowchartName;
    public string myVarName;
    [Space(10f)]
    [Header("Whether to use Bool or Int. only check one")]
    public bool pushBool;
    public bool pushInt;
    [Space(10f)]
    public int varInt;
    public bool varBool;

    List<GameObject> myFlowcharts = new List<GameObject>();

    private void Start() {
        GameObject[] myFlowchartObj = GameObject.FindGameObjectsWithTag("Flowchart");
        for (int i = 0; i < myFlowchartObj.Length; i++) {
            myFlowcharts.Add(myFlowchartObj[i]);
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
