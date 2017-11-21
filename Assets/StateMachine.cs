using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    public Stack<IState> currentState;

    public WanderBehavior wanderState;
    public EvadeWander evadeState;
    public SeekBehavior seekState;

	// Use this for initialization
	void Start ()
    {
        currentState = new Stack<IState>();
        wanderState = GetComponent<WanderBehavior>();
        evadeState = GetComponent<EvadeWander>();
        seekState = GetComponent<SeekBehavior>();
        currentState.Push(seekState);
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentState.Peek().DoAction();
        currentState.Peek().updateState(this);
	}
}
