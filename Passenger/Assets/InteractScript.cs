using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour {

    public GameObject traveller;
    public GameObject scientist;
    public GameObject officer;
    public GameObject lawyer;
    public GameObject engineer;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

      
	}

    private void OnTriggerStay(Collider other)
    {

        //do a raycast here to see which character player is pointing at
        if (Input.GetMouseButtonDown(0)) { 

            //if player triggers character object
            if (other.gameObject.CompareTag("Traveller"))
            {
                traveller.SetActive(true);
            }
            if (other.gameObject.CompareTag("Scientist"))
            {
                scientist.SetActive(true);
            }
            if (other.gameObject.CompareTag("Officer"))
            {
                officer.SetActive(true);
            }
            if (other.gameObject.CompareTag("Lawyer"))
            {
                lawyer.SetActive(true);
            }
            if (other.gameObject.CompareTag("Engineer"))
            {
                engineer.SetActive(true);
            }

     }


    }

}
