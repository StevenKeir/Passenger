using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static int gameIntensity; // used to automatically change the soundscape (higher number has more intese music, 0 = no music)

    public int introTalkInt; // for activating door trigger in the first scene

	// Use this for initialization
	void Start () {

        gameIntensity = 1;

        introTalkInt = 0;

	}
	
	// Update is called once per frame
	void Update () {
        

	}

   
}
