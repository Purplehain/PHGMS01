using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarchingCube{

    public List<Vector3> vertices = new List<Vector3>();
    public List<int> triangles = new List<int>();
    public List<Vector3> uvs = new List<Vector3>();

    public bool isSurrounded = false;

    public void GenerateMesh(int x, int y, int z) {
        if ( !isSurrounded ) {
            //FaceDataUp
            vertices.Add( new Vector3( x - 0.5f , y + 0.5f , z + 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y + 0.5f , z + 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y + 0.5f , z - 0.5f ) );
            vertices.Add( new Vector3( x - 0.5f , y + 0.5f , z - 0.5f ) );
            AddTriangles();

            //FaceDataDown
            vertices.Add( new Vector3( x - 0.5f , y - 0.5f , z - 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y - 0.5f , z - 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y - 0.5f , z + 0.5f ) );
            vertices.Add( new Vector3( x - 0.5f , y - 0.5f , z + 0.5f ) );
            AddTriangles();

            //FaceDataNorth
            vertices.Add( new Vector3( x + 0.5f , y - 0.5f , z + 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y + 0.5f , z + 0.5f ) );
            vertices.Add( new Vector3( x - 0.5f , y + 0.5f , z + 0.5f ) );
            vertices.Add( new Vector3( x - 0.5f , y - 0.5f , z + 0.5f ) );
            AddTriangles();

            //FaceDataEast
            vertices.Add( new Vector3( x + 0.5f , y - 0.5f , z - 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y + 0.5f , z - 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y + 0.5f , z + 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y - 0.5f , z + 0.5f ) );
            AddTriangles();

            //FaceDataSouth
            vertices.Add( new Vector3( x - 0.5f , y - 0.5f , z - 0.5f ) );
            vertices.Add( new Vector3( x - 0.5f , y + 0.5f , z - 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y + 0.5f , z - 0.5f ) );
            vertices.Add( new Vector3( x + 0.5f , y - 0.5f , z - 0.5f ) );
            AddTriangles();

            //FaceDataWest
            vertices.Add( new Vector3( x - 0.5f , y - 0.5f , z + 0.5f ) );
            vertices.Add( new Vector3( x - 0.5f , y + 0.5f , z + 0.5f ) );
            vertices.Add( new Vector3( x - 0.5f , y + 0.5f , z - 0.5f ) );
            vertices.Add( new Vector3( x - 0.5f , y - 0.5f , z - 0.5f ) );
            AddTriangles();
        }
        
    }


    public void AddTriangles() {
        triangles.Add( vertices.Count - 4 );
        triangles.Add( vertices.Count - 3 );
        triangles.Add( vertices.Count - 2 );

        triangles.Add( vertices.Count - 4 );
        triangles.Add( vertices.Count - 2 );
        triangles.Add( vertices.Count - 1 );

    }

    

}
