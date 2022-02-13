using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float characterSpeed;

    public Transform rootTransform;

    public bool canMove = false;

    [SerializeField] private Animator animator;


    public InputController inputController;

    
    //The method where we change the character animation.    
    public void ChangeAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    //The method we set what your character will do when the game is over.
    private void FinishGame()
    {
        canMove = false;
        inputController.canMove = false;
        animator.Play("FinishDance");
        UIManager.GetInstance().EndGame();
    }

    //The method that detects what hits the collider of the object and acts accordingly
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            FinishGame();
        }
    }

    void Update()
    {
        if (canMove)
        {
            rootTransform.Translate(Vector3.forward * Time.deltaTime * characterSpeed);
           
        }

    }

    


}
