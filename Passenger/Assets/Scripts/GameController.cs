using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static int gameIntensity; // used to automatically change the soundscape (higher number has more intese music, 0 = no music)

    public bool hasDuctape;
    public bool patchedHole;
    public bool foundEngineer;
     

    // Use this for initialization
    void Start () {

        gameIntensity = 1;

	}
	
	// Update is called once per frame
	void Update () {
        

	}

   
}
