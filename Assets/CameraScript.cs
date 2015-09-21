using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public Transform camera;
    public Transform player;
    public float height;
    public float distance;

	// Use this for initialization
	void Start () {
        camera = this.transform;
        AllignCamera(height, distance);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AllignCamera(float hei, float dis)
    {
        camera.position = player.position + new Vector3(0, hei, -dis);
    }
}
