using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class nextSceneE : MonoBehaviour
{

    public int lvl;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lvl = SceneManager.GetActiveScene().buildIndex + 1;
            Analytics.CustomEvent("LevelEnd, Switch to new Scene" + lvl);
            //SaveSystem.SavePlayer(this);
            PlayerPrefs.SetInt("lastLvl", lvl);
            SceneManager.LoadScene(lvl);
        }
    }
}
