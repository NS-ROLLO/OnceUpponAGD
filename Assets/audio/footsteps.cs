using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    CharacterController _characterController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_characterController.isGrounded && _characterController.velocity.magnitude>2 && GetComponent<AudioSource>().isPlaying == false && Time.timeScale == 1f)
        {
            GetComponent<AudioSource>().volume = Random.Range(0.6f, 0.9f);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
            GetComponent<AudioSource>().Play();

        }
    
        
    
    }
}
