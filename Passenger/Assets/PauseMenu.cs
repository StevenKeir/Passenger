using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {


    public GameObject pauseMenu;
    public GameObject pauseBackground;
    public bool paused;

    private void Awake()
    {
        paused = false;
    }

    private void Update()
    {
        Pause();
    }

    void Pause()
    {
        if ((paused == false) && (Input.GetKeyDown(KeyCode.Escape)))
        {
            Time.timeScale = 0.75f;
            pauseBackground.SetActive(true);
            pauseMenu.SetActive(true);
            paused = true;
        }else if(paused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseBackground.SetActive(false);
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
        
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseBackground.SetActive(false);
        pauseMenu.SetActive(false);
        paused = false;
    }
}
