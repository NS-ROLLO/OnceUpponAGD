using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class mainMenu : MonoBehaviour
{

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayNewGame()
    {
        Analytics.CustomEvent("New Game play at" + System.DateTime.Now);
        SceneManager.LoadScene(2);//SceneManager.GetActiveScene().buildIndex+1
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
   public void ContinueGame()
    {

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //PlayerData data = SaveSystem.LoadPlayer();
        //Debug.Log(data.lastScene + " load GAMEEEE");
        // SceneManager.LoadScene(data.lastScene);
        int myint = PlayerPrefs.GetInt("lastLvl");
        SceneManager.LoadScene(myint);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
