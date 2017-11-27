using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehavior : MonoBehaviour {


    Rigidbody rb;
    public float speed;
    public Transform target;
    public float slowingDistance;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}


    public void DoAction()
    {
        Vector3 targetOffset = target.position - transform.position;
        float rampedSpeed = speed * (targetOffset.magnitude / slowingDistance);
        float clippedSpeed = Mathf.Min(rampedSpeed, speed);
        Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
        rb.velocity = desiredVelocity;
    }

    // Update is called once per frame
    void Update ()
    {
      
        //rb.AddForce(desiredVelocity - rb.velocity);
	}
}
