using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    
    #region Singleton


    private static StackManager instance;

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

    public static StackManager GetInstance()
    {
        return instance;
    }


    #endregion

    public List<DiamondController> diamonds = new List<DiamondController>();

    public Transform stackParent;

    public float distance;

    public Transform firstDiamondTransform;


    public void AddDiamond(DiamondController diamond)
    {
        diamonds.Add(diamond);
        diamond.transform.SetParent(stackParent);

        diamond.transform.position = new Vector3(0, 1f, distance * diamonds.Count);

    }

    public Transform GetLastDiamondTransform()
    {
        if (diamonds.Count <= 1)
            return firstDiamondTransform;

        return diamonds[diamonds.Count - 2].transform;

    }


}
