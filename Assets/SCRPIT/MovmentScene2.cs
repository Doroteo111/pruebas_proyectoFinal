using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentScene2 : MonoBehaviour
{
    private float horizontalInput, verticalInput; //movment
    private float moveSpeed;
    public float turnSpeed = 60f; //speed
    public float walkSpeed = 8f;
    public float runSpeed= 20f;

   public float jumpForce = 10f;

    

    private bool isOnTheGround;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
   
    }
    private void Update()
    {
        Movment();
        if (Input.GetKeyDown(KeyCode.Mouse0)) //left botton down
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround ) //salto con el espacio y no podré saltar si es gameover(MUERTO)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision otherCollider) //collider ground
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


       transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        else if (Input.GetKey(KeyCode.LeftShift)) 
        {
            Run();
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            Idle();
        }
    }

    private void Idle()
    {
        _animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        _animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    private void Run()
    {
        moveSpeed = runSpeed;
        _animator.SetFloat("Speed", 1f, 0.1f,Time.deltaTime); //adding the smooth
    }
    private void Jump()
    {
        isOnTheGround = false;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
       
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
