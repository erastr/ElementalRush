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

    public void PayGateCost(DiamondController dia)
    {
        var diamond = diamonds.Find(x => x == dia);

        diamond.GetComponent<Collider>().enabled = false;

        diamonds.Remove(diamond);

        Destroy(diamond.gameObject);

        for (int i = 0; i < diamonds.Count; i++)
        {
            if (i==0)
                diamonds[i].targetTransform = firstDiamondTransform;
            else
                diamonds[i].targetTransform = diamonds[i - 1].transform;

        }
    }

    public void RemoveDiamondFromList(DiamondController diamond)
    {
        var index = diamonds.FindIndex(x => x == diamond);

        var count = diamonds.Count - index;

        var list = diamonds.GetRange(index, count);

        for (int i = 0; i < list.Count; i++)
        {
            diamonds.Remove(list[i]);

            if (i==0)
                Destroy(diamond.gameObject);
            else
            {
                diamonds.Remove(list[i]);
                list[i].Throw();
            }
          
           
        }

    }

    public void RemoveAllDiamondFromList()
    {
        if (diamonds.Count <= 0)
            return;

        var list = diamonds.GetRange(0, diamonds.Count);

        for (int i = 0; i < list.Count; i++)
        {
            diamonds.Remove(list[i]);
            list[i].Throw();
        }
    }

    public void Throw(DiamondController diamond)
    {
        var index = diamonds.FindIndex(x => x == diamond);

        for (int i = index; i < diamonds.Count; i++)
        {
           
            //diamonds[i].Throw();
            //diamonds.Remove(diamonds[i]);
        }
    }


}
