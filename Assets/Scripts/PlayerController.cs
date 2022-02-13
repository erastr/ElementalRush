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

    
  
    public void ChangeAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    private void FinishGame()
    {
        canMove = false;
        inputController.canMove = false;
        animator.Play("FinishDance");
        UIManager.GetInstance().EndGame();
    }


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
