using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadMainMenu()
    {
        Debug.Log("loading menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        int myint = PlayerPrefs.GetInt("lastLvl");
        SceneManager.LoadScene(myint);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
