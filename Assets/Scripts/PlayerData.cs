using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

[System.Serializable]
public class PlayerData
{
    public int lastScene;

    public PlayerData (SceneSwitch1 scene)
    {
        lastScene = scene.lvl;
        Debug.Log(scene.lvl+" SAVED GAMEEEE");
        Analytics.CustomEvent("Game Saved at" + scene.lvl);
    }

}
