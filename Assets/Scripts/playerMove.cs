using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

    public int moveSpeed;
    
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //walk right
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += gameObject.transform.right * moveSpeed * Time.deltaTime;
        }

        //walk left
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += gameObject.transform.right * -1 * moveSpeed * Time.deltaTime;
        }
	}
}
