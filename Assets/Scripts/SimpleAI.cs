using UnityEngine;
using System.Collections;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class SimpleAI : MonoBehaviour {

    public NavMeshAgent agent;
    public float curHealth = 100;
    public float maxHealth = 100;

    public float minDamage = 5;
    public float maxDamage = 10;

    public float hitChance = 80;
    public float blockChance = 40;

    public Transform target;
    public Vector3 roamTargetPos;


    void Awake( ) {
        agent = transform.GetComponent<NavMeshAgent>();
    }
    void Start() {
        
    }

    void Update() {
        
    }

    protected void CalculateDamage(float _min, float _max, float _hit) {

        if ( Random.Range( 0 , 100 ) < _hit && Random.Range(0,100) < blockChance ) {
            curHealth -= Mathf.Round(Random.Range(_min, _max));
            if(curHealth <= 0 ) {
                Destroy( gameObject );
            }
        }
        
    }

    public void SetTarget(Vector3 tar) {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(tar, path);
        agent.SetPath( path );
        roamTargetPos = tar;
    }

}
