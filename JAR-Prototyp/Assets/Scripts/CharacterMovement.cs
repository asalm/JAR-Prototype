using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float speed;
    public float gravity;
    public float jumpForce;
    public float smoothing;
    private Vector3 moveDirection = Vector3.zero;

   
    private float smoothHorizontalMovement;
    private float forwardSpeedV;

    //Assign CharacterController to Script in Inspector plx!
    public CharacterController controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Smoothing 

        smoothHorizontalMovement = Mathf.SmoothDamp(smoothHorizontalMovement, Input.GetAxisRaw("Horizontal") * speed, ref forwardSpeedV, smoothing );

        moveDirection = new Vector3(0, moveDirection.y, smoothHorizontalMovement);

        if (!controller.isGrounded)
            //moveDirection -= new Vector3(0, gravity * Time.deltaTime, 0);
            moveDirection.y -= gravity * Time.deltaTime;   
        else
            moveDirection.y = 0;

        if(controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
    
        //moveDirection = transform.TransformDirection(moveDirection);         

        //PlayerRotation (funkzt aber noch nicht :( )
        float faceDirection = Input.GetAxisRaw("Horizontal");

        if (faceDirection != 0)
        {
            transform.rotation = new Quaternion(0, 0, 0,0);
        }
        //Gravity
        moveDirection.y -= gravity * Time.deltaTime;
        // Move Character Controller
        controller.Move(moveDirection * Time.deltaTime);

        if (transform.position.y <= -10) //Fall des Character
            spawn();
	}

    //Collision with Enemy
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TopCollider"))
        {
            GameObject.Find("Enemy").SetActive(false);
            other.gameObject.SetActive(false);
           
        }
        else if(other.gameObject.CompareTag("SideCollider"))

        {
            spawn();
        }

    }

    void spawn() // Character spawnt zum Startpunkt wenn er fällt
    {
        transform.position = new Vector3(-5.5f, 18f, -1.3f);
    }

}
