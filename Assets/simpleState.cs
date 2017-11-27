using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum States
{
    state1,
    state2,
    state3,
    startOver
}

public class simpleState : MonoBehaviour {


    States myState;
    WanderBehavior wander;
    SeekBehavior seek;
    ArriveBehavior arrive;

    public float timer;
    private float startTimer;

	// Use this for initialization
	void Start ()
    {
        startTimer = timer;
        wander = GetComponent<WanderBehavior>();
        seek = GetComponent<SeekBehavior>();
        arrive = GetComponent<ArriveBehavior>();
	}
	


    void switchStates()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            myState++;
            if (myState == States.startOver)
            {
                myState = States.state1;
            }
            timer = startTimer;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        switch (myState)
        {
            case States.state1:
                wander.DoAction();
                break;
            case States.state2:
                seek.DoAction();
                break;
            case States.state3:
                arrive.DoAction();
                break;
        }
        switchStates();
    }
}
