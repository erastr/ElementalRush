using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    private GateType currentGateType;


    #region Singleton


    private static GateManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            if (instance != this)
                Destroy(this);
        }

    }

    public static GateManager GetInstance()
    {
        return instance;
    }


    #endregion



    public void SetGateType(GateType type)
    {
        currentGateType = type;

        switch (currentGateType)
        {
            case GateType.waterGate:
                Debug.Log("SelectedWaterGate");
                break;
            case GateType.fireGate:
                Debug.Log("SelectedFireGate");
                break;
            case GateType.earthGate:
                Debug.Log("SelectedEarthGate");
                break;
        }

    }


}
