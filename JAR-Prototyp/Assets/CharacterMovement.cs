using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float speed = 6.0F;
    public float gravity = 1.0F;
    public float jumpForce = 2F;
    private Vector3 moveDirection = Vector3.zero;

    //Assign CharacterController to Script in Inspector plx!
    public CharacterController controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float faceDirection = Input.GetAxisRaw("Horizontal");
        if(controller.isGrounded)
        {
            if (Input.GetKeyDown("space"))
            {
                moveDirection = new Vector3(0, jumpForce * Time.deltaTime, Input.GetAxis("Horizontal"));
            } else
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            }
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        //PlayerRotation (funkzt aber noch nicht :( )
        if (faceDirection != 0)
        {
            transform.rotation = new Quaternion(0, 0, 0,0);
        }
        //Gravity
        moveDirection.y -= gravity * Time.deltaTime;
        // Move Character Controller
        controller.Move(moveDirection * Time.deltaTime);
	}
}
