using UnityEngine;
using System.Collections;

public class DeactivateRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
	}
}
