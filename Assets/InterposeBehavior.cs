using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class InterposeBehavior : MonoBehaviour, IState {


    public GameObject thing1;
    public GameObject thing2;

    public float speed;
    Rigidbody rb;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void DoAction()
    {
        Vector3 midPoint = thing1.transform.position - thing2.transform.position;
        float midPointTime = Vector3.Distance(midPoint,transform.position) / speed;

        Vector3 aPos = thing1.transform.position + thing1.GetComponent<Rigidbody>().velocity * midPointTime;
        Vector3 bPos = thing2.transform.position + thing2.GetComponent<Rigidbody>().velocity * midPointTime;

        Vector3 desiredMidPoint = (aPos + bPos) / 2;
        agent.destination = desiredMidPoint;
        Debug.DrawLine(transform.position, desiredMidPoint);

        //if(Vector3.Distance(transform.position,desiredMidPoint) > 1)
        //{
        //    rb.drag = 0;
        //    Vector3 dir = transform.position + desiredMidPoint;
        //    rb.AddForce(dir.normalized * speed);
        //}
        //else { rb.drag = 5; }
    }
    public bool CheckState()
    {
        return true;
    }
    public void updateState(Object stateManager)
    {

    }

}
