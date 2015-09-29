using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class SimpleAI : MonoBehaviour
{
	public Transform[] waypoints;
	public int waypointIndex = 0;
	protected NavMeshAgent agent;
	public float curHealth = 100;
	public float maxHealth = 100;

	public float minDamage = 5;
	public float maxDamage = 10;

	public float hitChance = 80;
	public float blockChance = 40;

	public Transform target;
	public Vector3 roamTargetPos;

	protected bool canSeeTarget;
	public bool onPatrol;

	protected WaypointManager wayPointManager = new WaypointManager ();
	protected StateMachine stateMachine = new StateMachine ();


	void Awake ()
	{
		agent = transform.GetComponent<NavMeshAgent> ();
	}

	public void CalculateDamage (float _min, float _max, float _hit)
	{

		if (Random.Range (0, 100) < _hit) {

			if (Random.Range (0, 100) < blockChance) {
				curHealth -= Mathf.Round (Random.Range (_min, _max));
				if (curHealth <= 0) {
					Destroy (gameObject);
				}
			} else {
				Debug.Log ("Blocked");
			}
		} else {
			Debug.Log ("Missed");
		}
        
	}

	public void SetTarget (Vector3 tar)
	{
		NavMeshPath path = new NavMeshPath ();
		agent.CalculatePath (tar, path);
		agent.SetPath (path);
		roamTargetPos = tar;
	}

	float patrolIdleCnt = 0;
	public void Patrol ()
	{
		if (onPatrol) {

			if (!ReachedTarget (transform.position, waypoints [waypointIndex].position))
				SetTarget (waypoints [waypointIndex].position);
			else if (ReachedTarget (transform.position, waypoints [waypointIndex].position)) {
				waypointIndex++;
				if (waypointIndex + 1 > waypoints.Length)
					waypointIndex = 0;
			}

		}
	}
	
	public void Chase ()
	{
		
	}
	
	public void Attack ()
	{
		
	}


	public IEnumerator Idle ()
	{
		yield return new WaitForSeconds (5);
		RoamAround (20);
	}

	Vector3 cachedPos;
	float roamIdleCnt = 0;
	public void RoamAround (float radius)
	{
		if (cachedPos == transform.position) {
			roamIdleCnt += Time.deltaTime;
		}
		
		if (roamIdleCnt > 1 || ReachedTarget (transform.position, roamTargetPos)) {
			target = null;
			roamIdleCnt = 0;
		}
		if (target == null) {
			//Debug.Log( "Roaming around "+roamTargetPos );
			
			Vector3 rndTarget = new Vector3 (transform.position.x + Random.Range (-radius, radius), transform.position.y, transform.position.z + Random.Range (-radius, radius));
			RaycastHit hit = new RaycastHit ();
			
			if (Physics.Raycast (new Vector3 (rndTarget.x, rndTarget.y + 1000, rndTarget.z), Vector3.down, out hit, 2000)) {
				bool reachAble = true;
				for (int x = -1; x < 1; x++) {
					for (int y = -1; y < 1; y++) {
						RaycastHit testHit = new RaycastHit ();
						if (Physics.Raycast (new Vector3 (rndTarget.x + (x * 0.5f), rndTarget.y + 1000, rndTarget.z + (y * 0.5f)), Vector3.down, out testHit)) {
							if (testHit.transform.tag != "Ground") {
								reachAble = false;
							}
							
						}
					}
				}
				if (hit.transform.tag == "Ground" && reachAble)
					SetTarget (rndTarget);
				target = transform;
				
			}
		}
		cachedPos = transform.position;
	}
	
	public bool ReachedTarget (Vector3 origin, Vector3 tar)
	{
		if (Vector3.Distance (origin, tar) <= .75f) {
			return true;
		} else
			return false; 
	}
	
	void OnDrawGizmos ()
	{
		Gizmos.DrawCube (roamTargetPos, Vector3.one * .3f);
		Gizmos.DrawLine (transform.position, roamTargetPos);
	}

}
