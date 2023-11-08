using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{


public class PressKeyOpenDoor : MonoBehaviour
{

    public GameObject Instruction;
    public GameObject Instruction2;
    public GameObject Instruction3;
    //public GameObject AnimeObject;
    public Animator Animator;
    public Animator Animator2;
    public GameObject ThisTrigger;
    public bool Action = false;
    public bool DoorStatus = false;
    bool canOpen = false;
    [SerializeField] private KryInventory _keyinventory = null;
    void Start()
    {
        Instruction.SetActive(false);
        Instruction2.SetActive(false);
        Instruction3.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {
            if (_keyinventory.hasKey)
            {
                if (collision.transform.tag == "Player" && DoorStatus == false)
                {
                    Instruction.SetActive(true);
                    Action = true;
                    canOpen = true;
                }
                else
                {
                    Instruction2.SetActive(true);
                    Action = true;
                    canOpen = true;
                }
            }
            else
            {
                if (collision.transform.tag == "Player")
                {
                    Instruction3.SetActive(true);
                    canOpen = false;
                }
            }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Instruction2.SetActive(false);
        Instruction3.SetActive(false);
        Action = false;
        canOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && DoorStatus == false && canOpen == true)
        {
            Instruction.SetActive(false);
            Animator.Play("DoorOpen", 0, 0.0f);
            Animator2.Play("DoorOpen2", 0, 0.0f);
            //ThisTrigger.SetActive(false);
            Action = false;
            DoorStatus = true;
        }
        else if(Input.GetKeyDown(KeyCode.E) && DoorStatus == true && canOpen == true)
        {
            Instruction2.SetActive(false);
            Animator.Play("DoorClose", 0, 0.0f);
            Animator2.Play("DoorClose2", 0, 0.0f);
            //ThisTrigger.SetActive(false);
            Action = false;
            DoorStatus=false;
        }
    }
}
}