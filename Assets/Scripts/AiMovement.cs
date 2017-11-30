using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour {

	public int speed;
	public int xpos;
	public Rigidbody2D rb;
	private SpriteRenderer mySpriteRenderer;
	private playerMove player;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		player = GameObject.FindObjectOfType<playerMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xpos, 0));
		if (mySpriteRenderer.flipX == false) {
			rb.AddForce (Vector2.right * speed * xpos);
			if (hit.distance < 1.5f) {
				flipAi ();
				mySpriteRenderer.flipX = true;
				if (hit.collider.tag == "Player") {
					player.Jump ();
					StartCoroutine (Wait ());
				}
			}
		} else
		if (mySpriteRenderer.flipX == true) {
			rb.AddForce (Vector2.right * speed * xpos);
			if (hit.distance < 1.5f) {
				flipAi ();
				mySpriteRenderer.flipX = false;
				if (hit.collider.tag == "Player") {
					player.Jump ();
					StartCoroutine (Wait ());
				}
			}
		}
	}

	void flipAi (){
		xpos = xpos * -1;
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.80f);
		player.killPlayer ();
	}
}
