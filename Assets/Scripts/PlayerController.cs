using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerController : MonoBehaviour {

    public PaCTarget pacTarget;

    public GameObject[] fungus;
    public bool fungusIsActive;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        FungusActive();
	}

    void FungusActive ()
    {
        fungusIsActive = false;
        for (int i = 0; i < fungus.Length - 1; i++)
        {
            if (fungus[i].activeInHierarchy)
            {
                fungusIsActive = true;
                break;
            }
        }

        if (fungusIsActive == true)
        {
            pacTarget.inputEnabled = false;
        }
        else
        {
            pacTarget.inputEnabled = true;
        }
    }

    void FungusUpdateTalker() {

        var sayDialog = Fungus.SayDialog.GetSayDialog();
        var menuDialog = Fungus.MenuDialog.GetMenuDialog();


        if (!sayDialog.isActiveAndEnabled && !menuDialog.isActiveAndEnabled) {
            pacTarget.inputEnabled = true;
        } else {
            pacTarget.inputEnabled = false;
        }

    }

}
