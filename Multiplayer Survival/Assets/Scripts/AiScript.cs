using UnityEngine;
using System.Collections;

public class AiScript : MonoBehaviour
{
	public Transform target;
	public GameObject[] patrolPoints;

	// Use this for initialization
	void Start ()
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = target.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void Patrol ()
	{
	}
}
