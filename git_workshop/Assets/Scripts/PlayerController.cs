using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float topSpeed;
    public float acceleration;
    public float jumpPower;

    public GameObject mainCamera;

    // private by default
    Rigidbody2D rb2d;
    SpriteRenderer spriteRen;

    bool grounded;

	// Use this for initialization
	void Start ()
    {
        // get a reference to component
        rb2d = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddForce(new Vector2(acceleration, 0));
            spriteRen.flipX = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddForce(new Vector2(-acceleration, 0));
            spriteRen.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb2d.AddForce(new Vector2(0, jumpPower));
        }

        // limit character speed to 5
        if (rb2d.velocity.x > 5)
        {
            rb2d.velocity = new Vector2(topSpeed, rb2d.velocity.y);
        }
        else if (rb2d.velocity.x < -5)
        {
            rb2d.velocity = new Vector2(-topSpeed, rb2d.velocity.y);
        }

        
    }

    private void OnCollisionStay2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        grounded = false;
    }
}
