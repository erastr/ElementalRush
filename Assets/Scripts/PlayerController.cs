using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float characterSpeed;

    public Transform rootTransform;

    // Update is called once per frame
    void Update()
    {
        rootTransform.Translate(Vector3.forward * Time.deltaTime * characterSpeed);
    }






}
