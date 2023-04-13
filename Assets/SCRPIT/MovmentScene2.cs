using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentScene2 : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 60f; //speed

    private float horizontalInput, verticalInput; //movment

    private Animator _animator; //aniamtion

    private void Start()
    {
       
        _animator = GetComponent<Animator>();
       
    }
    private void Update()
    {
        //Movment
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        /*transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);*/

        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);


    }
}
