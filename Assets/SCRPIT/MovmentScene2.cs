using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovmentScene2 : MonoBehaviour
{
    private float verticalInput; //movment
    private float moveSpeed;
    public bool hasStamina=true;
    public  float turnSpeed = 60f; //speed
    public const float WALK_SPEED = 8f;
    public const float RUN_SPEED = 20f;

    public float jumpForce = 10f;

    public float mouseSensitivity;

    private bool isOnTheGround;
    private Rigidbody _rigidbody;
    private Animator _animator;


    //reference other script

    public float staminaUseAmount = 5f;
    private UIStaminaBar staminaSlider; 



    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked; //press [esc] to exit the mode

        staminaSlider = FindObjectOfType<UIStaminaBar>(); 

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
       
        verticalInput = Input.GetAxis("Vertical");
       transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * verticalInput); //right,horizontal

        float mouseX = Input.GetAxis("Mouse X"); //mouse rotation
                                                 
        transform.Rotate(Vector3.up, mouseSensitivity * mouseX * Time.deltaTime);

        if (!(verticalInput != 0))
        {
            Idle();
        }
        else if (Input.GetKey(KeyCode.LeftShift) && hasStamina) 
        {
             Run();
        }
        else 
        {
            Walk();
        }
    }

    private void Idle()
    {
        moveSpeed = 0;
        _animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = WALK_SPEED;
        _animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

        //adding stamina bar
        staminaSlider.UseStamina(0); 
    }
    private void Run()
    {
        moveSpeed = RUN_SPEED;
        _animator.SetFloat("Speed", 1f, 0.1f,Time.deltaTime); //adding the smooth

        //adding stamina bar
        staminaSlider.UseStamina(staminaUseAmount);
    }
    private void Jump()
    {
        isOnTheGround = false;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
       
    }

    private void Attack()
    {
        _animator.SetInteger("Attack_type", Random.Range(1, 3));
        _animator.SetTrigger("Attack");
    }
}
