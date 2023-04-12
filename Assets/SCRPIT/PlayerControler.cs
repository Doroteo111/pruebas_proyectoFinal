using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerOb;
    //public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        //if we want the cursor invisible
        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/
    }
    private void Update()
    {
        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;


        //rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        if(inputDir != Vector3.zero)
        {
            playerOb.forward = Vector3.Slerp(playerOb.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

    }
  

}
