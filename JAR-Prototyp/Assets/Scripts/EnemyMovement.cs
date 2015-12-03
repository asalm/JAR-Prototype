using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    private int currentPoint = 0;
    private Vector3[] patrol = new Vector3[2];
    

	// Use this for initialization
	void Start () {
        patrol[0] = new Vector3(-5.5f, 1.5f, 21);
        patrol[1] = new Vector3(-5.5f, 1.5f, 15.5f);
    }
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(transform.position, patrol[currentPoint]) < 0.5f)
        {
            currentPoint++;
        }

        if(!(currentPoint < patrol.Length))
        {
            currentPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrol[currentPoint], speed * Time.deltaTime);
    }
}
