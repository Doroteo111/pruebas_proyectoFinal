using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentScene2 : MonoBehaviour
{
    private float horizontalInput, verticalInput; //movment
    public float turnSpeed = 60f; //speed
    public float walkSpeed = 8f;
    public float runSpeed= 20f;

   public float jumpForce = 10f;

    

    private bool isOnTheGround;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
   
    }
    private void Update()
    {
        Movment();
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround ) //salto con el espacio y no podré saltar si es gameover(MUERTO)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }
   
    private void Movment()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


       transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            //walk
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            //run
        }
    }

    private void Jump()
    {
        isOnTheGround = false;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //_animator.SetTrigger("Jump_trig"); 

    }
}
