using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotateDuration = 0.5f;
    [SerializeField] private RotateType rotateType;

    [Range(-360,360)]
    [SerializeField] private float rotateDegree;
    [SerializeField] private RotateMode rotateMode;
    [SerializeField] private LoopType loopType;
    private void Awake() 
    {
        switch (rotateType)
        {
            case RotateType.Right:
                transform.DOLocalRotate(Vector3.right * rotateDegree, rotateDuration, rotateMode).SetLoops(-1,loopType).SetEase(Ease.Linear);
                break;
            case RotateType.Left:
                transform.DOLocalRotate(Vector3.left * rotateDegree, rotateDuration, rotateMode).SetLoops(-1,loopType).SetEase(Ease.Linear);
                break;
            case RotateType.Up:
                transform.DOLocalRotate(Vector3.up * rotateDegree, rotateDuration, rotateMode).SetLoops(-1,loopType).SetEase(Ease.Linear);
                break;
            case RotateType.Down:
                transform.DOLocalRotate(Vector3.down * rotateDegree, rotateDuration, rotateMode).SetLoops(-1,loopType).SetEase(Ease.Linear);
                break;
            case RotateType.Forward:
                transform.DOLocalRotate(Vector3.forward * rotateDegree, rotateDuration, rotateMode).SetLoops(-1,loopType).SetEase(Ease.Linear);
                break;
            case RotateType.Back:
                transform.DOLocalRotate(Vector3.back * rotateDegree, rotateDuration, rotateMode).SetLoops(-1,loopType).SetEase(Ease.Linear);
                break;
            default:
                break;
        }
    }
    
    public enum RotateType
    {
        Right,
        Left,
        Up,
        Down,
        Forward,
        Back
    }
}
