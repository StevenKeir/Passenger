using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class SceneChange : MonoBehaviour {

    public bool talkedToCharactersSceneOne;
    public string sceneName;
    //public Collider doorTrigger;
    public Collider caveTrigger;
    public int introTalkInt; // for activating door trigger in the first scene



    private void Start()
    {

        //doorTrigger.enabled = false;
        talkedToCharactersSceneOne = false;
        introTalkInt = 0;


    }

    void Update() {

        if (introTalkInt >= 2) {
            talkedToCharactersSceneOne = true;
        }

        if (talkedToCharactersSceneOne == true) {
            //doorTrigger.enabled = true;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Passenger")
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    void SceneSwap() {

        SceneManager.LoadScene("Bus");

    }
}
