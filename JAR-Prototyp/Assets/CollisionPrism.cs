using UnityEngine;
using System.Collections;

public class CollisionPrism : MonoBehaviour {

    public GameObject door;
    public AudioSource source;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        source.Play();
        Destroy(door);
    }
}
