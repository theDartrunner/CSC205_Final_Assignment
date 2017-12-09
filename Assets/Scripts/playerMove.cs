using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

    public int moveSpeed;
    public int jumpForce;
    public Rigidbody2D rb;
    public Animator anim;
    private SpriteRenderer mySpriteRenderer;
	public bool isGrounded = true;
	public GameObject turtleShell;

    void Start () {

        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

		PlayerRaycast ();

        //stop walk animation
		if (Input.GetKeyUp(KeyCode.D))
        {
            //anim.SetTime(0);
            anim.SetBool("walk", false);
        }

        //walk right
        if (Input.GetKey(KeyCode.D))
        {
            if (mySpriteRenderer.flipX == false)
            {
                gameObject.transform.position += gameObject.transform.right * moveSpeed * Time.deltaTime;
                //anim.SetTime(1);
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
            //anim.SetTime(0);    
            anim.SetBool("walk", false);
        }

        //walk left
        if (Input.GetKey(KeyCode.A))
        {
            if (mySpriteRenderer.flipX == true)
            {
                gameObject.transform.position += gameObject.transform.right * -1 * moveSpeed * Time.deltaTime;
                //anim.SetTime(1);
                anim.SetBool("walk", true); // start walk animation
            }

            else
            {
                mySpriteRenderer.flipX = true; // sprite image face left 
            }
        }

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) {
			Jump ();
		}
    }

	public void Jump () {
		rb.AddForce (Vector2.up * jumpForce);
		anim.SetBool("jump", true); // start jump animation
		isGrounded = false;
	}

    // see if player is touching the floor and stop jump animation
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Floor" || hit.gameObject.tag == "horiz_move" || hit.gameObject.tag == "vert_move")
        {
			isGrounded = true;
            anim.SetBool("jump", false);
		}

        
        
    }

    //Mario jumps ontop of turtle Ai
    void PlayerRaycast(){ 
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
		if(hit.distance < 2.0f && hit.collider.tag == "Enemy"){
			
			//Only jumps if perfect jump centered over Ai
			Jump ();

			Destroy (hit.collider.gameObject);
			Instantiate (turtleShell, new Vector2 (transform.position.x, 0), transform.rotation);
		}
	}
}
