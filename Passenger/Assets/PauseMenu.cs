using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {


    public GameObject pauseMenu;
    public GameObject pauseBackground;

    private void Update()
    {
        Pause();
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.75f;
            pauseBackground.SetActive(true);
            pauseMenu.SetActive(true);
        }
        
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseBackground.SetActive(false);
        pauseMenu.SetActive(false);
    }



}
