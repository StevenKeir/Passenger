using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool seated;

    // Use this for initialization
    void Start () {

       playerAnim = player.GetComponent <Animator> ();
       lawyerAnim = lawyer.GetComponent<Animator>();
       officerAnim = officer.GetComponent<Animator>();
       scientistAnim = scientist.GetComponent<Animator>();
       travellerAnim = traveller.GetComponent<Animator>();

        seated = true;
    }
	
	// Update is called once per frame
	void Update () {

        Seated();

	}

    void Seated() {

        if (seated == true) {
            playerAnim.SetBool("Seated", true);
            lawyerAnim.SetBool("Seated", true);
            officerAnim.SetBool("Seated", true);
            scientistAnim.SetBool("Seated", true);
            travellerAnim.SetBool("Seated", true);
        }

    }

}
