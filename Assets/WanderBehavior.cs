using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : MonoBehaviour, IState {



    public float speed = 1;
    public float radius = 1;
    public float jitter = 1;
    public float distance = 1;
    public Vector3 steeringForce;
    public Vector3 target;
    Rigidbody rb;
    public float timer;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}


    public void DoAction()
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


    public bool CheckState()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            
            timer = 4;
            return true;
        }
        return false;
    }

    public void updateState(Object stateManager)
    {
        if(CheckState())
        {
            var manager = (StateMachine)stateManager;
            manager.currentState.Pop();
            manager.currentState.Push(manager.evadeState);
        }
    }


// Update is called once per frame
void Update () {
		
	}
}
