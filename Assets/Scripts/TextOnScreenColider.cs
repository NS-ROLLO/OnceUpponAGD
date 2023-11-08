using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnScreenColider : MonoBehaviour
{
    [SerializeField] private GameObject InstructionWasd;
    [SerializeField] private GameObject InstructionE;
    void OnTriggerEnter(Collider collision)
    {
        InstructionWasd.SetActive(true);
        InstructionE.SetActive(true);
    }

    private void OnTriggerExit(Collider collision)
    {
        InstructionWasd.SetActive(false);
        InstructionE.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    void Start()
    {
        InstructionE.SetActive(false);


    }
}
