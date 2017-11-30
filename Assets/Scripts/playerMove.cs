using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

    public int moveSpeed;
    public int jumpForce;
    public Rigidbody2D rb;
    public Animator anim;
    private bool jumping;
    private SpriteRenderer mySpriteRenderer;

    void Start () {

        jumping = false;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        //stop walk animation
		if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetTime(0);
            anim.SetBool("walk", false);
        }

        //walk right
        if (Input.GetKey(KeyCode.D))
        {
            if (mySpriteRenderer.flipX == false)
            {
                gameObject.transform.position += gameObject.transform.right * moveSpeed * Time.deltaTime;
                anim.SetTime(1);
                anim.SetBool("walk", true); // start walk animation
                
            }
            else
            {
                mySpriteRenderer.flipX = false; // sprite image face right
            }
        }

        // stop walk animation
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetTime(0);    
            anim.SetBool("walk", false);
        }

        //walk left
        if (Input.GetKey(KeyCode.A))
        {
            if (mySpriteRenderer.flipX == true)
            {
                gameObject.transform.position += gameObject.transform.right * -1 * moveSpeed * Time.deltaTime;
                anim.SetTime(1);
                anim.SetBool("walk", true); // start walk animation
            }

            else
            {
                mySpriteRenderer.flipX = true; // sprite image face left 
            }
        }

       
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
 
            jumping = true;
            rb.AddForce(Vector2.up * jumpForce);
            anim.SetBool("jump", true); // start jump animation
        }
    }

    // see if player is touching the floor and stop jump animation
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Floor")
        {
            jumping = false;
            anim.SetBool("jump", false);
        }
    }
}
