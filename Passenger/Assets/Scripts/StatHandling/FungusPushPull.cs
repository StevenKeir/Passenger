using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
public class FungusPushPull : MonoBehaviour {
    Scene myScene;
    Scene oldScene;
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    GameObject[] myObjArray;

    public List<Flowchart> myFlowcharts = new List<Flowchart>();

    public List<string> boolName = new List<string>();
    public List<string> intName = new List<string>();

    public List<bool> myBool = new List<bool>();
    public List<int> myInt = new List<int>();

    void CustomStart() {
        myObjArray = GameObject.FindGameObjectsWithTag("Flowchart");
    }

    private void Update() {
        myScene = SceneManager.GetActiveScene();
        if (myScene != oldScene) {
            CustomStart();
        }
        LoadFromFungus();

        oldScene = myScene;
    }

    void LoadFromFungus() {
        for (int i = 0; i < myObjArray.Length; i++) {
            myFlowcharts.Add(myObjArray[i].GetComponent<Flowchart>());
            for (int f = 0; f < myFlowcharts[i].GetVariableNames().Length; f++) {

                //The following section checks for whether a bool exists. Fungus is stupid and dumb and sets this check to "false" if it does not, meaning I can't get it's value from this.
                //to counter that, I have done the following:
                //if true, simple: the value is true, set it's bool and list name
                //If it returns false, turn the value true
                //if the value is now true, it exists, set it back to false, set it's name and value in other lists.
                if (myFlowcharts[i].GetBooleanVariable(myFlowcharts[i].GetVariableNames()[f]) == true) {
                    boolName.Add(myFlowcharts[i].GetVariableNames()[f]);
                    myBool.Add(myFlowcharts[i].GetBooleanVariable(myFlowcharts[i].GetVariableNames()[f]));
                }
                else {
                    myFlowcharts[i].SetBooleanVariable(myFlowcharts[i].GetVariableNames()[f], true);
                    if (myFlowcharts[i].GetBooleanVariable(myFlowcharts[i].GetVariableNames()[f]) == true) {
                        myFlowcharts[i].SetBooleanVariable(myFlowcharts[i].GetVariableNames()[f], false);
                        boolName.Add(myFlowcharts[i].GetVariableNames()[f]);
                        myBool.Add(myFlowcharts[i].GetBooleanVariable(myFlowcharts[i].GetVariableNames()[f]));
                    }
                }

                //The following section checks for whether a bool exists. Fungus is stupid and dumb and sets this check to "0" if it does not, meaning I can't get it's value from this.
                //to counter that, I have done the following:
                //add 1 to the value
                //check for it's existence
                //if the value is now 1 or more, it exists (this does not work for -1)
                //set the integer's name and number, and before that -1
                myFlowcharts[i].SetIntegerVariable(myFlowcharts[i].GetVariableNames()[f], myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]) + 1);
                if (myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]) != 0) {
                    myFlowcharts[i].SetIntegerVariable(myFlowcharts[i].GetVariableNames()[f], myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]) - 1);
                    intName.Add(myFlowcharts[i].GetVariableNames()[f]);
                    myInt.Add(myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]));
                }


            }
        }
    }
}