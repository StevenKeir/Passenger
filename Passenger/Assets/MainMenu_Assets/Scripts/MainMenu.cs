using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    StatsHandler mySH;
    private void Start() {
        mySH = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
    }

    public void StartGame()
    {
        mySH.NewGame();
    }

    public void LoadGame() {
        mySH.ContinueGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
