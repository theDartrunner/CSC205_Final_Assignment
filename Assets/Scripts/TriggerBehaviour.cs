using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehaviour : MonoBehaviour {
    public GameObject column;

    void Start()
    {
        Debug.Log(this.name + " " + this.tag);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.tag == "reverse_trigger")
        {
            if (other.tag == "gem")
            {
                column.GetComponent<Renderer>().enabled = false;
                column.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            if (other.tag == "gem")
            {
                column.GetComponent<Renderer>().enabled = true;
                column.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (this.tag == "reverse_trigger")
        {
            if (other.tag == "gem")
            {
                column.GetComponent<Renderer>().enabled = true;
                column.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else
        {
            if (other.tag == "gem")
            {
                column.GetComponent<Renderer>().enabled = false;
                column.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
