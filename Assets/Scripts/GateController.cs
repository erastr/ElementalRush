using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GateController : MonoBehaviour
{
    [SerializeField] private int gateID;
    [SerializeField] private DiamondCategory category;

    [SerializeField] private int cost = 5;

    [SerializeField] private TextMeshPro costText;


    private void Start()
    {
        costText.text = cost.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Diamond"))
        {
            if (other.gameObject.GetComponent<DiamondController>().isCollectable)
            {
                return;
            }
            List<DiamondController> diamondList = StackManager.GetInstance().diamonds;

            for (int i = diamondList.Count-1; i >= 0; i--)
            {

                if (Equals(diamondList[i].category,category))
                {
                    cost--;
                    costText.text = cost.ToString();

                    StackManager.GetInstance().PayGateCost(diamondList[i]);

                    if (cost == 0)
                    {
                        Destroy(gameObject);
                    }
                    break;
                }

            }

        }
        else if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.rootTransform.DOBlendableLocalMoveBy(Vector3.back * 10, 0.5f);
            StackManager.GetInstance().DestroyAllDiamond();
            Destroy(gameObject);
        }

    }


}
