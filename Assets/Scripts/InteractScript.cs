using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour {

    public SceneChange sceneChange; // reference to scene load script
    public GameObject flowchart;
    public bool mouseOver;
    public bool talked;
    public bool maxTalk;

    // Use this for initialization
    void Start () {

        talked = false;
        if (talked == true)
        {
            sceneChange.introTalkInt++;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerStay(Collider other)
    {
        if (mouseOver == true) {

            //do a raycast here to see which character player is pointing at
            if (Input.GetMouseButtonDown(0)) {

                if (other.gameObject.CompareTag("Player"))
                {
                    flowchart.SetActive(true);
                    if (talked != true)
                    {
                        sceneChange.introTalkInt++;
                        talked = true;
                    }
                }

            }

        }
    }

    private void OnMouseEnter()
    {
        mouseOver = true;

    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

}
