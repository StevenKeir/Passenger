using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BusIntroScript : MonoBehaviour {

    public GameObject player;
    public Animator playerAnim;
    public GameObject lawyer;
    public Animator lawyerAnim;
    public GameObject officer;
    public Animator officerAnim;
    public GameObject scientist;
    public Animator scientistAnim;
    public GameObject traveller;
    public Animator travellerAnim;

    public bool intro;
    public bool scene2;

    // Use this for initialization
    void Start () {

       playerAnim = player.GetComponent <Animator> ();
       lawyerAnim = lawyer.GetComponent<Animator>();
       officerAnim = officer.GetComponent<Animator>();
       scientistAnim = scientist.GetComponent<Animator>();
       travellerAnim = traveller.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (intro == true) {
            Intro();
        }
        if (scene2 == true)
        {
            Scene2();
        }
        */
    }

    void Intro() {

            playerAnim.SetBool("Seated", true);
            lawyerAnim.SetBool("Seated", true);
            officerAnim.SetBool("Seated", true);
            scientistAnim.SetBool("Seated", true);
            travellerAnim.SetBool("Seated", true);
        
    }

    void Scene2() {

        officerAnim.SetBool("Pickup", true);
        lawyerAnim.SetBool("Seated", true);
        
    }

    void IntroSequence ()
    {
        Intro();
    }

    void Scene2Sequence()
    {
        Scene2();
    }

}
