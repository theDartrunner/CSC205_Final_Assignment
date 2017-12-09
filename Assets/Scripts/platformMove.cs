using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour {

    public float maxMoveDistance = 10;
    public float speed = 10;
    public Vector3 origin;
    public Vector3 destination;

    void Start()
    {
        origin = transform.position;
        destination = origin;
    }

    void Update()
    {
        if (this.tag == "vert_move") { 
            if (destination == transform.position)
            {
                destination = origin;
            }
            if (origin == transform.position)
            {
                destination = new Vector3(origin.x, origin.y + maxMoveDistance, origin.z);
            }
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        } else if(this.tag == "horiz_move")
        {
            if (destination == transform.position)
            {
                destination = origin;
            }
            if (origin == transform.position)
            {
                destination = new Vector3(origin.x + maxMoveDistance, origin.y, origin.z);
            }
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }
}
