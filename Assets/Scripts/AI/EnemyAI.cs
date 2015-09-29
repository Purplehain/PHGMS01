using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : SimpleAI
{
	public AIState state;

	void Awake ()
	{
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}

	// Use this for initialization
	void Start ()
	{
		state = AIState.Idle;
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		DecideState ();
	}

	void DecideState ()
	{
		switch (state) {
		case AIState.Attack:
			Attack ();
			break;
		case AIState.Idle:
			Idle ();
			break;
		case AIState.Patrol:
			Patrol ();
			break;
		case AIState.Chase:
			Chase ();
			break;
		}
	}
}

public enum AIState
{
	Idle,
	Patrol,
	Attack,
	Chase
}
;
