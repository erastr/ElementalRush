using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    [SerializeField] private Transform diamondParent;

    public Transform targetTransform;

    private float distance = 1f;

    public bool isCollectable = true;


    private void Start()
    {
        distance = StackManager.GetInstance().distance;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name);
        if (other.CompareTag("Player") && isCollectable)
        {
            StackManager.GetInstance().AddDiamond(this);
            isCollectable = false;
            targetTransform = StackManager.GetInstance().GetLastDiamondTransform();
        }
        else if (other.CompareTag("Diamond") && isCollectable)
        {
            isCollectable = false;
            StackManager.GetInstance().AddDiamond(this);
            targetTransform = StackManager.GetInstance().GetLastDiamondTransform();
        }
    }

    private void Update()
    {
        MoveDiamond();
    }

    private void MoveDiamond()
    {
       
        if (isCollectable)
            return;

        if (targetTransform != null)
        {
            var targetPos = targetTransform.transform.position + Vector3.forward * distance;

            var targetX = Mathf.Lerp(transform.position.x, targetTransform.transform.position.x, 0.09f);

            var pos = targetPos;

            pos.x = targetX;

            transform.position = pos;
        }
    }


    //Engele çarptýðýmýzda diamond ileriye fýrlayacak
    public void Throw()
    {
        isCollectable = true;
        targetTransform = null;
    }

}
