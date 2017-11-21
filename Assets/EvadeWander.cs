using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeWander : MonoBehaviour, IState {

    public GameObject Prey;
    public float speed;
    Rigidbody rb;

    public void DoAction()
    {
        Vector3 dir = (Prey.transform.position - transform.position).normalized;
        Vector3 desiredVelocity = -dir * speed;


        Vector3 steeringForce = desiredVelocity - rb.velocity;
        rb.AddForce(steeringForce);
        Vector3 head = rb.velocity;
        head.y = 0;
        transform.LookAt(transform.position + head, Vector3.up);
    }


    public bool CheckState()
    {
        return Vector3.Distance(transform.position, Prey.transform.position) > 10;
    }
    public void updateState(Object stateManager)
    {

        if (CheckState())
        {
            var manager = (StateMachine)stateManager;
            manager.currentState.Pop();
            manager.currentState.Push(manager.seekState);
        }
    }


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
