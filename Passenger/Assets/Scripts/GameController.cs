using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static int gameIntensity;

	// Use this for initialization
	void Start () {

        gameIntensity = 1;

	}
	
	// Update is called once per frame
	void Update () {
        
	}


    /* void OnTriggerEnter(Collider collider)
     {
         // Check if we ran into a coin
         if (collider.gameObject.tag == "Player")
         {
             print("Dialogue Activate");


         } 

     }*/
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dialogue Activate");
        //if player triggers object fire dialogue
        /* if (other.gameObject.CompareTag("Trigger"))
         {
             // print("Dialogue Activate");
             Debug.Log("Dialogue Activate");
             //Set active dialogue here somehow

            // other.gameObject.name == "Trigger"
         }*/

    }

   
}
