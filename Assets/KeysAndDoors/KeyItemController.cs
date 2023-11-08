using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool reddoor = false;
        [SerializeField] private bool redKey = false;
        [SerializeField] private bool redLetter = false;
        [SerializeField] private KryInventory _keyinventory = null;
        [SerializeField] private AudioClip _audioComponent;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private GameObject _uiText;

        private KeyDoorController doorObject;
    


    private void Start()
    {
            if(reddoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
    }
        public void ObjectInteraction()
        {
            if (reddoor)
            {
                //doorObject.PlayAnimation();
            }
            else if (redKey)
            {
                _keyinventory.hasKey = true;
                gameObject.SetActive(false);
            }
            else if(redLetter)
            {
               
                //make ui visible 
                _audioSource.PlayOneShot(_audioComponent);
                _uiText.SetActive(true);
                gameObject.SetActive(false);
                //closu ui when e pressed
            }
            
        }

    }
}