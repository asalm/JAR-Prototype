using UnityEngine;
using System.Collections;

public class Trapdoor : MonoBehaviour {


    public GameObject trap;
    public bool left = true;
	// Use this for initialization
	void Start () {

        StartCoroutine(TrapDoor());
    }
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator TrapDoor()
    {
        while (true)
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
            yield return new WaitForSeconds(3.0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            yield return new WaitForSeconds(3.0f);
        }
    }
}
