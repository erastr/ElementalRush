using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{

    [SerializeField] List<GateController> gateControllers = new List<GateController>();

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



   






}
