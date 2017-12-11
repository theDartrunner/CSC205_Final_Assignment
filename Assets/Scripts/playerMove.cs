using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour {

    public int moveSpeed;
    public int jumpForce;
    public Rigidbody2D rb;
    public Animator anim;
    private SpriteRenderer mySpriteRenderer;
	public bool isGrounded = true;
    private bool holding = false;
	public GameObject turtleShell;
    public GameObject portalgun;
    public GameObject player;

	public AudioClip turtleDeath;
	public AudioClip playerJump;
	private AudioSource source;
	public AudioClip playerDeath;
	public AudioClip gameWin;

	void Awake () {
		source = GetComponent<AudioSource>();
	}

    void Start () {

        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

		PlayerRaycast ();


        // filp player depending on portal gun rotation 
        if (portalgun.transform.rotation.z > 0.7f || portalgun.transform.rotation.z < -0.7f) 
        {
            mySpriteRenderer.flipX = true;
        }

        else if (portalgun.transform.rotation.z < 0.7f || portalgun.transform.rotation.z > -0.7f)
        {
            mySpriteRenderer.flipX = false;
        }

        //stop walk animation
		if (Input.GetKeyUp(KeyCode.D))
        {
            
            anim.SetBool("walk", false);
        }

        //walk right
        if (Input.GetKey(KeyCode.D))
        {
            if (mySpriteRenderer.flipX == false)
            {
                gameObject.transform.position += gameObject.transform.right * moveSpeed * Time.deltaTime;
               
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
           
            anim.SetBool("walk", false);
        }

        //walk left
        if (Input.GetKey(KeyCode.A))
        {
            if (mySpriteRenderer.flipX == true)
            {
                gameObject.transform.position += gameObject.transform.right * -1 * moveSpeed * Time.deltaTime;
               
                anim.SetBool("walk", true); // start walk animation
            }

            else
            {
                mySpriteRenderer.flipX = true; // sprite image face left 
            }
        }

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true)
        {
			source.PlayOneShot (playerJump, 0.5f);
			Jump ();
		}

        // putting down objects
        if (holding && Input.GetKeyDown(KeyCode.E))
        {
            var item = GameObject.FindGameObjectWithTag("Item");
           
            item.transform.parent = null;
            item.transform.gameObject.tag = "Shell";
            item.GetComponent<Rigidbody2D>().gravityScale = 1f;
            holding = false;
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

        // picking up objects 
        if (hit.gameObject.tag == "Shell" )
        {
                Debug.Log("holding");
                hit.transform.parent = player.transform;
                hit.transform.localPosition = hit.transform.position = new Vector3(0.99f, -0.13f, 0f);
                hit.transform.gameObject.tag = "Item";
                hit.rigidbody.gravityScale = 0;
                holding = true;   
        }

		//boundary
		if (hit.gameObject.tag == "boundary" )
		{
			GameObject A = GameObject.FindGameObjectWithTag("music2");
			Destroy(A);
			source.PlayOneShot (playerDeath, 1.0f);
			StartCoroutine(Wait());
		}

		//enemy
		if (hit.gameObject.tag == "Enemy" )
		{
			GameObject A = GameObject.FindGameObjectWithTag("music2");
			Destroy(A);
			StartCoroutine(Wait());
		}

		//boundary
		if (hit.gameObject.tag == "exit" )
		{
			GameObject A = GameObject.FindGameObjectWithTag("music2");
			Destroy(A);
			source.PlayOneShot (gameWin, 1.0f);
			StartCoroutine (Wait2 ());
		}

		if (hit.gameObject.tag == "exit2" )
		{
			GameObject A = GameObject.FindGameObjectWithTag("music2");
			Destroy(A);
			source.PlayOneShot (gameWin, 1.0f);
			StartCoroutine (Wait3 ());
		}
        
        
    }

    //Mario jumps ontop of turtle Ai
    void PlayerRaycast(){ 
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
		if(hit.distance < 2.0f && hit.collider.tag == "Enemy"){
			
			//Only jumps if perfect jump centered over Ai
			Jump ();

			Destroy (hit.collider.gameObject);
			source.PlayOneShot (turtleDeath, 0.5f);
			Instantiate (turtleShell, new Vector2 (transform.position.x, 0), transform.rotation);
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene ("GameOver_Level2");
	}

	IEnumerator Wait2()
	{
		yield return new WaitForSeconds(6);
		SceneManager.LoadScene ("level1win");
	}

	IEnumerator Wait3()
	{
		yield return new WaitForSeconds(6);
		SceneManager.LoadScene ("level2win");
	}
}
