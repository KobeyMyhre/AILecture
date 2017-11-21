using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImanager : MonoBehaviour {

    WanderBehavior wander;
    Rigidbody rb;
    public float avoidanceStrength;
    public float avoidanceRange;
	// Use this for initialization
	void Start ()
    {
        wander = GetComponent<WanderBehavior>();
        rb = GetComponent<Rigidbody>();
	}


    public void doWallAvoidance()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 1, transform.forward, out hit, avoidanceRange))
        {
            rb.AddForce(hit.normal * avoidanceStrength);
        }


    }

    // Update is called once per frame
    void Update () {
        wander.DoAction();
        doWallAvoidance();
	}
}
