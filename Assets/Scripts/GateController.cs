using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

    [SerializeField] private GateType myGate;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            GateManager.GetInstance().SetGateType(myGate);
            GetComponent<Collider>().enabled = false;
        }

    }




}

public enum GateType
{
    waterGate = 0,
    fireGate = 1,
    earthGate = 2
}
