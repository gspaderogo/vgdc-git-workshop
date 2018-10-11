using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // private by default
    Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        // get a reference to component
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2d.AddForce(new Vector2(10, 0));
	}
}
