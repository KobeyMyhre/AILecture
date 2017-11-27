using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum AIstates
{
    wander,
    seek,
    evade,
    startOver
}


public class simpleStateMachine : MonoBehaviour {


    
    public float speed = 1;
    public float radius = 1;
    public float jitter = 1;
    public float distance = 1;
    public float Timer = 5;
    private float StartTimer;
    public AIstates myState;
    Rigidbody rb;
    public GameObject Prey;
    public Vector3 steeringForce;
    public Vector3 target;
    public float avoidanceRange;
    public float avoidanceStrength;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        StartTimer = Timer;
	}

    public void DoSeek()
    {
        Vector3 dir = (Prey.transform.position - transform.position).normalized;
        Vector3 desiredVelocity = dir * speed;


        Vector3 steeringForce = desiredVelocity - rb.velocity;
        rb.AddForce(steeringForce);
        Vector3 head = rb.velocity;
        head.y = 0;
        transform.LookAt(transform.position + head, Vector3.up);
    }



    public void DoEvade()
    {
        Vector3 dir = (Prey.transform.position - transform.position).normalized;
        Vector3 desiredVelocity = -dir * speed;


        Vector3 steeringForce = desiredVelocity - rb.velocity;
        rb.AddForce(steeringForce);
        Vector3 head = rb.velocity;
        head.y = 0;
        transform.LookAt(transform.position + head, Vector3.up);
    }


    public void doWallAvoidance()
    {
        RaycastHit hit;
        if(Physics.SphereCast(transform.position, 1, transform.forward, out hit, rb.velocity.magnitude))
        {
            rb.AddForce(hit.normal * avoidanceStrength);
        }
       

    }


    void switchStates()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            myState++;
            if(myState == AIstates.startOver)
            {
                myState = AIstates.wander;
            }
            Timer = StartTimer;
        }
    }


    public void DoWander()
    {
        
        target = Vector3.zero;


        //Random.InitState((int)transform.position.x);

        target = Random.insideUnitCircle.normalized * radius;

        target = (Vector2)target + Random.insideUnitCircle * jitter;
        target = target.normalized * radius;


        target.z = target.y;
        target.y = 0.0f;
        target += transform.position;
        target += transform.forward * distance;




        Vector3 dir = (target - transform.position).normalized;
        Vector3 desiredVelocity = dir * speed;





        steeringForce = desiredVelocity - rb.velocity;
        rb.AddForce(steeringForce);
        transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);

    }

    // Update is called once per frame
    void Update ()
    {
        switch(myState)
        {
            case AIstates.wander:
                DoWander();
                
                break;
            case AIstates.evade:
                DoEvade();
                break;
            case AIstates.seek:
                DoSeek();
                break;
        }
        switchStates();
        doWallAvoidance();
	}
}
