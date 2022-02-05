using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{


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
