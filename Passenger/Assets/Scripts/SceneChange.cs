using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour {

    public bool talkedToCharactersSceneOne;

    public string sceneName;

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
