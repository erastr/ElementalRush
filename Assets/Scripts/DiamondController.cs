using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DiamondController : MonoBehaviour
{

    public Transform targetTransform;

    private float distance = 1f;

    public bool isCollectable = true;

    [SerializeField] private float rotateDuration = 1;

    public DiamondCategory category;

    private void Start()
    {
        distance = StackManager.GetInstance().distance;
        transform.DOLocalRotate(Vector3.up * 360, rotateDuration, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Incremental).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherDiamond = other.GetComponent<DiamondController>();

        if (other.CompareTag("Player") && isCollectable)
        {
            StackManager.GetInstance().AddDiamond(this);
            isCollectable = false;
            targetTransform = StackManager.GetInstance().GetLastDiamondTransform();
        }

        else if (other.CompareTag("Diamond") && !isCollectable && otherDiamond.isCollectable)
        {
            otherDiamond.isCollectable = false;
            StackManager.GetInstance().AddDiamond(otherDiamond);
            otherDiamond.targetTransform = StackManager.GetInstance().GetLastDiamondTransform();
        }
        else if (other.CompareTag("Chest"))
        {
            Destroy(gameObject);
            UIManager.GetInstance().UpdateCoin();
        }
    }

    private void Update()
    {
        FollowDiamond();
    }

    private void FollowDiamond()
    {
       
        if (isCollectable)
            return;

        if (targetTransform != null)
        {
            var targetPos = targetTransform.transform.position + Vector3.forward * distance;

            var targetX = Mathf.Lerp(transform.position.x, targetTransform.transform.position.x, 0.22f);

            var pos = targetPos;

            pos.x = targetX;

            transform.position = pos;
        }
    }

   


    //Engele �arpt���m�zda diamond ileriye f�rlayacak
    public void Throw()
    {
        float leftLimitX = -2.5f;
        float rightLimitX = 2.5f;

        if (transform.position.x <= 0)
        {
            leftLimitX = Mathf.Abs(transform.position.x) - 2.5f;
            rightLimitX -= transform.position.x;
        }
        else
        {
            rightLimitX = 2.5f - transform.position.x;
            leftLimitX -= transform.position.x;
        }
        GetComponent<Collider>().enabled = false;

        targetTransform = null;
        isCollectable = true;

        var targetPos = new Vector3(Random.Range(leftLimitX, rightLimitX), 0, Random.Range(10, 20));


        transform.DOBlendableMoveBy(targetPos, 1);
        transform.DOBlendableMoveBy(Vector3.up * 1.5f, 0.5f).OnComplete(()=> 
        {
            transform.DOBlendableMoveBy(Vector3.up * -1.5f, 0.5f);
            GetComponent<Collider>().enabled = true;
        });

        //transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * 15);
    }


    private void OnDestroy()
    {
        transform.DOKill();
    }


}

public enum DiamondCategory
{
    Fire = 0,
    Water = 1,
    Earth = 2
}
