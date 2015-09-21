using System.Collections.Generic;
using UnityEngine;

public class MeshData {
    public List<Vector3> vertices = new List<Vector3>();
    public List<int> triangles = new List<int>();
    public List<Vector3> uvs = new List<Vector3>();

    public List<Vector3> colVertices;
    public List<int> colTriangles;
}
