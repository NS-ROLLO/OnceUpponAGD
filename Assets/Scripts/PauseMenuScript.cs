using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class PauseMenuScript : MonoBehaviour
{
  public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Debug.Log("game paused");
                Analytics.CustomEvent("Game Paused at " + System.DateTime.Now);
                Pause();
            }
        }
        
    }


    public void Resume() 
    { 


        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        MouseLook.LockCursor = false;
        Cursor.lockState = CursorLockMode.None;
    }


    public void LoadMainMenu()
    {
        Debug.Log("loading menu...");
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("game quit");
    }

}
