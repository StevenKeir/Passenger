using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ChangeFungusVar : MonoBehaviour
{

    [Header("Pulling")]
    public bool needsPull;
    //Name of the variable to pull from fungus as a string. case sensitive.
    public string varNameToPull;
    //reference to the Fungus puller script.
    FungusPushPull myFungusPull;
    [Space(5)]

    //Disables the collider if the pulled bool is false and this is true;
    public bool disableColliderOnFalse;

    //Disables the collider if the pulled bool is true and this is true;
    public bool disableColliderOnTrue;

    //Disables the collider if the pulled int is 0 and this is true;
    public bool disableColliderOn0;

    //Disables the collider if the pulled int is !=0 and this is true;
    public bool disableColliderOnBigger;
    [Space(5)]

    //whether or not to pull the int variable in fungus named varNameToPull
    public bool pullInt;

    //whether or not to pull the bool variable in fungus named varNameToPull
    public bool pullBool;
    [Space(15)]

    [Header("Pushing")]
    //the name of the Flowchart that holds the bool or int to push
    public string myFlowchartName;
    //the name of the variable to push
    public string myVarName;
    [Space(5f)]

    //push bool to fungus
    public bool pushBool;

    //push int to fungus
    public bool pushInt;
    [Space(5f)]

    public int varInt;
    public bool varBool;
    Collider myCol;
    [Space(15)]

    [Header("Pulled variables DO NOT TOUCH")]
    //empty int value to pull. should be 0.
    public int pulledInt;
    //empty bool value to pull. should be false.
    public bool pulledBool;

    List<GameObject> myFlowcharts = new List<GameObject>();

    private void Start()
    {
        if (GetComponent<Collider>())
        {
            myCol = GetComponent<Collider>();
        }
        myFungusPull = GameObject.FindGameObjectWithTag("FungusPull").GetComponent<FungusPushPull>();
        GameObject[] myFlowchartObj = GameObject.FindGameObjectsWithTag("Flowchart");
        for (int i = 0; i < myFlowchartObj.Length; i++)
        {
            myFlowcharts.Add(myFlowchartObj[i]);
        }
    }

    private void Update()
    {
        if (needsPull)
        {
            if (pullBool)
            {
                pulledBool = myFungusPull.PullBool(varNameToPull, pulledBool);
            }
            if (pullInt)
            {
                pulledInt = myFungusPull.PullInt(varNameToPull, pulledInt);
            }
            ColliderChange();
        }
    }

    void ColliderChange()
    {
        if ((disableColliderOnFalse && !pulledBool) ||
            (disableColliderOnTrue && pulledBool) ||
            (disableColliderOn0 && pulledInt == 0) ||
            (disableColliderOnBigger && pulledInt > 0))
        {
            myCol.enabled = false;
        }
        else
        {
            myCol.enabled = true;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < myFlowcharts.Count; i++)
        {
            if (myFlowcharts[i].name == myFlowchartName)
            {
                if (pushBool)
                {
                    myFlowcharts[i].GetComponent<Flowchart>().SetBooleanVariable(myVarName, varBool);
                }
                if (pushInt)
                {
                    myFlowcharts[i].GetComponent<Flowchart>().SetIntegerVariable(myVarName, varInt);
                }
            }
        }
    }
}
