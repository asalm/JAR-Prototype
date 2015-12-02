using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour
{

    public float speed = 4.0f;
    public float border1 = -5, border2 = 5;
    public bool turn = false;
    public int axis = 3;
    float posX, posY, posZ;
    float moveAxis;

    // Use this for initialization
    void Start()
    {
        float change;
        if (border1 > border2) // swap borders if User fucked it up
        {
            change = border1;
            border1 = border2;
            border2 = change;
        }

    }

    // Update is called once per frame
    void Update()
    {

        posY = transform.position.y;
        posX = transform.position.x;
        posZ = transform.position.z;

        if (moveAxis >= border1 && turn == false)
        {
            moveAxis -= speed * Time.deltaTime;
        }
        else
        {
            if (moveAxis <= border2)
            {
                moveAxis += speed * Time.deltaTime;
            }

            if (moveAxis > border2)
                turn = false;
        }
        if (moveAxis < border1)
            turn = true;

        

        if ( axis == 1)
            transform.position = new Vector3(moveAxis, posY, posZ);
        else if(axis == 2)
            transform.position = new Vector3(posX, moveAxis, posZ);
        else if(axis == 3)
            transform.position = new Vector3(posX, posY, moveAxis);
        else
        {
            Debug.Log("Only 3 Axis available. \n Continue with Axis 3");
            //if Users made a wrong input, the default axis is used (z-Axis)
            transform.position = new Vector3(posX, posY, moveAxis);
        }

    }

    void OnCollisionEnter(Collision collision) //klappt noch nicht wie es sollte!
    {
        Debug.Log("kollision");
        turn = !turn;
    }
}
