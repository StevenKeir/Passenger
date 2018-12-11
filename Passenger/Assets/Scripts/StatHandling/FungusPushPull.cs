using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class FungusPushPull : MonoBehaviour {

    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //For the purpose of ease of use, the following two public functions are all you need to worry about, everything else is just how it handles 
    //pulling and allowing use of the following two functions.

    //The function below is for pulling bools from Fungus - or, rather, this list's version of fungus, which should update every update frame.
    //and below that is the function for pulling ints.

    //In order to use either of these, you need to put {FungusPushPull myFPull = GameObject.FindGameObjectWithTag("FungusPull").GetComponent<FungusPushPull>();} 
    //somewhere in the script that needs it, then put {myFPull.PullBool(nameOfBool, thisObjectsBool);} where "nameOfBool" is the name of the bool 
    //in Fungus, and "thisObjectsBool" is the saved variable in the script.

    //Same thing for PullInt, only replace the bools with ints.

    public bool PullBool(string name, bool boolToChange) {
        bool returnBool = boolToChange;
        bool hasReturned = false;
        for (int i = 0; i < boolName.Count; i++) {
            if (boolName[i] == name && !hasReturned) {
                returnBool = myBool[i];
                hasReturned = true;
            }
        }
        return returnBool;
    }

    public int PullInt(string name, int intToChange) {
        int returnInt = intToChange;
        bool hasReturned = false;
        for (int i = 0; i < intName.Count; i++) {
            if (intName[i] == name && !hasReturned) {
                returnInt = myInt[i];
                hasReturned = true;
            }
        }
        return returnInt;
    }
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    //Below is everything to do with pulling info from Fungus. feel free to read and try to follow the spaghetti code.
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
            if (!myFlowcharts.Contains(myObjArray[i].GetComponent<Flowchart>())){
                myFlowcharts.Add(myObjArray[i].GetComponent<Flowchart>());
            }
            for (int f = 0; f < myFlowcharts[i].GetVariableNames().Length; f++) {

                //The following section checks for whether a bool exists. Fungus is stupid and dumb and sets this check to "false" if it does not, meaning I can't get it's value from this.
                //to counter that, I have done the following:
                //if true, simple: the value is true, set it's bool and list name
                //If it returns false, turn the value true
                //if the value is now true, it exists, set it back to false, set it's name and value in other lists.
                if (myFlowcharts[i].GetBooleanVariable(myFlowcharts[i].GetVariableNames()[f]) == true) {
                    if (!boolName.Contains(myFlowcharts[i].GetVariableNames()[f])) {
                        boolName.Add(myFlowcharts[i].GetVariableNames()[f]);
                    }
                    myBool.Add(myFlowcharts[i].GetBooleanVariable(myFlowcharts[i].GetVariableNames()[f]));
                }
                else {
                    myFlowcharts[i].SetBooleanVariable(myFlowcharts[i].GetVariableNames()[f], true);
                    if (myFlowcharts[i].GetBooleanVariable(myFlowcharts[i].GetVariableNames()[f]) == true) {
                        myFlowcharts[i].SetBooleanVariable(myFlowcharts[i].GetVariableNames()[f], false);
                        if (!boolName.Contains(myFlowcharts[i].GetVariableNames()[f])) {
                            boolName.Add(myFlowcharts[i].GetVariableNames()[f]);
                        }
                        myBool.Add(myFlowcharts[i].GetBooleanVariable(myFlowcharts[i].GetVariableNames()[f]));
                    }
                }

                //The following section checks for whether an int exists. Fungus is stupid and dumb and sets this check to "0" if it does not, meaning I can't get it's value from this.
                //to counter that, I have done the following:
                //The same as above, except instead of setting it to false, adds one to the value.

                if (myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]) != 0) {
                    if (!intName.Contains(myFlowcharts[i].GetVariableNames()[f])) {
                        intName.Add(myFlowcharts[i].GetVariableNames()[f]);
                    }
                    myInt.Add(myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]));
                }
                else {
                    myFlowcharts[i].SetIntegerVariable(myFlowcharts[i].GetVariableNames()[f], myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]) + 1);
                    if (myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]) != 0) {
                        if (!intName.Contains(myFlowcharts[i].GetVariableNames()[f])) {
                            intName.Add(myFlowcharts[i].GetVariableNames()[f]);
                        }
                        myInt.Add(myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]));
                        myFlowcharts[i].SetIntegerVariable(myFlowcharts[i].GetVariableNames()[f], myFlowcharts[i].GetIntegerVariable(myFlowcharts[i].GetVariableNames()[f]) - 1);
                    }
                }
            }
        }
    }


}