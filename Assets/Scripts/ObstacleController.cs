using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{

    //The method that detects what hits the collider of the object and acts accordingly
    private void OnTriggerEnter(Collider other)
    {
        if (Equals(other.tag,"Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            StackManager.GetInstance().RemoveAllDiamondFromList();

            player.rootTransform.DOBlendableLocalMoveBy(Vector3.back * 10, 0.5f);
            

        }
        if (Equals(other.tag,"Diamond"))
        {

            DiamondController diamond = other.GetComponent<DiamondController>();

            if (!diamond.isCollectable)
            {
                StackManager.GetInstance().RemoveDiamondFromList(diamond);
            }


        }
    }

}
