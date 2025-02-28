using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup_Mesh_Creation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        Tile = Instantiate(prefabTile, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
        Object prefab = Resources.Load("Tile");
        Tile.transform.SetParent(gameObject.transform);

        //creates initial mesh
        Mesh mesh = new Mesh();
        vertices[0] = new Vector3(0,0,0);
        vertices[1] = new Vector3(0,0,1);
        vertices[2] = new Vector3(1,0,1);
        vertices[3] = new Vector3(1,0,0);
        

        //triangle 1
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        //triangle 2
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        Tile.GetComponent<MeshFilter>().mesh = mesh;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
