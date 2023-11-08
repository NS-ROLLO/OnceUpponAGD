using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeLetterUi : MonoBehaviour
{
    [SerializeField] private GameObject _gameobject;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _gameobject.SetActive(false);
        }
    }
}
