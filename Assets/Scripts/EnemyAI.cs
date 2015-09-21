using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : SimpleAI {

    private bool canSeeTarget;
    private bool onPatrol;


    private List<Waypoint> wayPoints = new List<Waypoint>();

    
    void Awake( ) {
        //target = GameObject.FindGameObjectWithTag( "Player" ).transform.position;
        
    }
	// Use this for initialization
	void Start () {

        target = null;
	}
	
	// Update is called once per frame
	void Update () {
        
        RoamAround(Random.Range(5,20));
	}

    public void Patrol() {
        int cnt = 0;

        if(onPatrol && wayPoints.Count > 0 ) {
            for ( int i = 0 ; i < wayPoints.Count ; i++ ) {
                if ( cnt > wayPoints.Count ) { cnt = 0; }
                if (wayPoints[i].position == transform.position ) {
                    cnt++;
                }
            }
        }
    }

    public void Chase( ) {

    }

    public void Attack( ) {

    }

    public void RoamAround(float radius) {
        if(ReachedTarget( transform.position , roamTargetPos ) ) {
            target = null;
        }
        if ( target == null) {
            Debug.Log( "Roaming around "+roamTargetPos );
            
            Vector3 rndTarget = new Vector3(transform.position.x + Random.Range(-radius,radius), transform.position.y, transform.position.z + Random.Range(-radius,radius));
            RaycastHit hit = new RaycastHit();
            
            if ( Physics.Raycast( new Vector3( rndTarget.x , rndTarget.y + 1000 , rndTarget.z ) , Vector3.down , out hit , 2000 ) ) {
                bool reachAble = true;
                for ( int x = -1 ; x < 1 ; x++ ) {
                    for ( int y = -1 ; y < 1 ; y++ ) {
                        RaycastHit testHit = new RaycastHit();
                        if(Physics.Raycast( new Vector3(rndTarget.x + (x*0.5f) , rndTarget.y + 1000 , rndTarget.z + (y*0.5f)), Vector3.down, out testHit ) ) {
                            if ( testHit.transform.tag != "Ground") {
                                reachAble = false;
                            }
                            
                        }
                    }
                }
                if(hit.transform.tag == "Ground" && reachAble)
                    SetTarget( rndTarget );
                    target = transform;
                
            }
        }
    }
    
    public bool ReachedTarget(Vector3 origin, Vector3 tar) {
        if(origin == tar) {
            return true;
        }
        else return false; 
    }

    void OnDrawGizmos( ) {
        Gizmos.DrawCube( roamTargetPos , Vector3.one*.3f );
        Gizmos.DrawLine( transform.position , roamTargetPos );
    }
}
