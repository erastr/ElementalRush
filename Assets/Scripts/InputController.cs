using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private float leftLimitX, rightLimitX;

    [SerializeField] private float sideMovementSensitivity = 5f;
    [SerializeField] private float sideMovementLerpSpeed = 20f;

    private float sideMovementTarget;

    private Vector2 inputDrag;
    private Vector2 inputStartPosition;

    public bool canMove = false;


    private Vector2 mousePosCM
    {
        get
        {
            var pos = Input.mousePosition;
            var inches = pos / Screen.dpi;
            var centimeters = inches / 2.54f;

            return centimeters;
        }
    }

    private void Update()
    {
        if (canMove)
        {
            HandleSideMovement();
            HandleInput();
        }
    }

    //The method in which we move the player to the right and left
    private void HandleSideMovement()
    {
        sideMovementTarget += inputDrag.x * sideMovementSensitivity;
        sideMovementTarget = Mathf.Clamp(sideMovementTarget, leftLimitX, rightLimitX);
        
        var localPos = sideMovementRoot.localPosition;
        
        localPos.x = Mathf.Lerp(localPos.x, sideMovementTarget, Time.deltaTime * sideMovementLerpSpeed);

        sideMovementRoot.localPosition = localPos;
    }

    //Required method for the handle side movement method to work
    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inputStartPosition = mousePosCM;
        }
        if (Input.GetMouseButton(0))
        {
            inputDrag = mousePosCM - inputStartPosition;
            inputStartPosition = mousePosCM;

        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }

}
