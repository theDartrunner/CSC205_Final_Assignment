using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

    public int moveSpeed;
    public int jumpForce;
    private SpriteRenderer mySpriteRenderer;
    private bool jumping;
    public Rigidbody2D rb;


    void Start () {

        jumping = false;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
		
        //walk right
        if (Input.GetKey(KeyCode.D))
        {
            if (mySpriteRenderer.flipX == false)
            {
                gameObject.transform.position += gameObject.transform.right * moveSpeed * Time.deltaTime;
            }

            else
            {
                mySpriteRenderer.flipX = false; // sprite image face right
            }
        }

        //walk left
        if (Input.GetKey(KeyCode.A))
        {
            if (mySpriteRenderer.flipX == true)
            {
                gameObject.transform.position += gameObject.transform.right * -1 * moveSpeed * Time.deltaTime;
            }

            else
            {
                mySpriteRenderer.flipX = true; // sprite image face left 
            }
        }

        // jump only when player on the floor 
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
 
            jumping = true;
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    // see if player is touching the floor 
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Floor")
        {
            jumping = false;
        }
    }
}
