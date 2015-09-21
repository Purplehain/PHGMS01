using UnityEngine;
using System.Collections;

public class Waypoint{

    public Vector3 position;
    public Waypoint[] connectedWaypoints;

    public Waypoint(Vector3 pos) {
        position = pos;
    }
}
