using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class SceneChange : MonoBehaviour {

    public bool talkedToCharactersSceneOne;

    public string sceneName;

    public Collider doorTrigger;


    private void Start()
    {

        doorTrigger.enabled = false;
        talkedToCharactersSceneOne = false;

    }

    void Update() {

        if (talkedToCharactersSceneOne == true) {
            doorTrigger.enabled = true;
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
