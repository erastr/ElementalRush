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

    //We add coins to the stack list and the method we give the position of the object that this coin should follow
    public void AddDiamond(DiamondController diamond)
    {
        diamonds.Add(diamond);
        diamond.transform.SetParent(stackParent);

        diamond.transform.position = new Vector3(0, 1f, distance * diamonds.Count);

    }

    //The method where we give the position of the last coin in the list
    public Transform GetLastDiamondTransform()
    {
        if (diamonds.Count <= 1)
            return firstDiamondTransform;

        return diamonds[diamonds.Count - 2].transform;

    }

    //The method by which the fee for the gate passed is paid
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

    //The method in which the incoming coin is deleted from the list
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
    //Method to delete all coins from list
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

    //Method that destroys all coins
    public void DestroyAllDiamond()
    {
        if (diamonds.Count <= 0)
            return;

        var list = diamonds.GetRange(0, diamonds.Count);

        for (int i = 0; i < list.Count; i++)
        {
            GameObject go = list[i].gameObject;
            diamonds.Remove(list[i]);
            Destroy(go);
            
        }
    }

    //The method where we throw the incoming coin forward
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
