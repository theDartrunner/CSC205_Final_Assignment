using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portals : MonoBehaviour {

    bool moved; 

	// Use this for initialization
	void Start () {
        moved = false;
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

            if (gameObject.tag == "portalB")
            {
                coll.gameObject.transform.position = GameObject.FindGameObjectWithTag("portalO").transform.position;
                gameObject.GetComponent<Collider2D>().enabled = false;
                GameObject.FindGameObjectWithTag("portalO").GetComponent<Collider2D>().enabled = false;
                StartCoroutine(wait());
                moved = true;
            }

            if (gameObject.tag == "portalO")
            {
                coll.gameObject.transform.position = GameObject.FindGameObjectWithTag("portalB").transform.position;
                gameObject.GetComponent<Collider2D>().enabled = false;
                GameObject.FindGameObjectWithTag("portalB").GetComponent<Collider2D>().enabled = false;
                StartCoroutine(wait());
                moved = true;
        }
    }


    IEnumerator wait()
    {
        //Debug.Log("wait1");
        yield return new WaitForSeconds(.25f);
        GameObject.FindGameObjectWithTag("portalB").GetComponent<Collider2D>().enabled = true;
        GameObject.FindGameObjectWithTag("portalO").GetComponent<Collider2D>().enabled = true;
        //Debug.Log("wait2");
    }


}
