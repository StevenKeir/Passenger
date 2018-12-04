using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour {

    public GameObject flowchart;

    public bool mouseOver;

    // Use this for initialization
    void Start () {
		
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
