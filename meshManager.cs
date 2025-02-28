using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshManager : MonoBehaviour
{
    //reference to other scripts
    //*********************************************
    public MapTileData dataManager;
    //*********************************************

    //cliff mesh data
    //*********************************************
    Mesh cliffMesh;
    GameObject Cliff;
    public Vector3[] cliff_vertices = new Vector3[16];
    int[] cliff_triangles = new int[24];
    Vector2[] cliff_uv = new Vector2[16];
    //*********************************************

    //tile mesh data
    //*********************************************
    public GameObject prefabTile;
    public GameObject cliffPrefabTile;
    GameObject Tile;
    Vector3[] vertices = new Vector3[4];
    int[] triangles = new int[6];
    Vector2[] uv = new Vector2[4];
    int count = 0;
    //*********************************************

    private void Awake() 
    {
        dataManager = GameObject.FindGameObjectWithTag("TerrainData").GetComponent<MapTileData>();
    }

    void Start()
    {
        count = 0;
        for(int i = 0; i < dataManager.xTiles; i++)
        {
            for(int j = 0; j < dataManager.zTiles; j++)
            {
                Tile = Instantiate(prefabTile, dataManager.tiledata[count].terrainTileObjectLocation, Quaternion.identity) as GameObject;
                //Tile = Instantiate(prefabTile, new Vector3(0,0,0), Quaternion.identity) as GameObject;
                //Tile = Instantiate(prefabTile, dataManager.tiledata[count].terrainVertices[3], Quaternion.identity) as GameObject;
                Object prefab = Resources.Load("Tile");
                Tile.transform.SetParent(gameObject.transform);

                //creates initial mesh
                Mesh mesh = new Mesh();

                vertices[0] = dataManager.tiledata[count].terrainVertices[0];
                vertices[1] = dataManager.tiledata[count].terrainVertices[1];
                vertices[2] = dataManager.tiledata[count].terrainVertices[2];
                vertices[3] = dataManager.tiledata[count].terrainVertices[3];

                uv[0] = new Vector2(0,0);
                uv[1] = new Vector2(0,1);
                uv[2] = new Vector2(1,1);
                uv[3] = new Vector2(1,0);
        
                //triangle 1
                triangles[0] = 0;
                triangles[1] = 1;
                triangles[2] = 2;
                //triangle 2
                triangles[3] = 0;
                triangles[4] = 2;
                triangles[5] = 3;
            
                mesh.vertices = vertices;
                mesh.uv = uv;
                mesh.triangles = triangles;

                Tile.GetComponent<MeshFilter>().mesh = mesh;
                Tile.AddComponent<MeshCollider>();
                Tile.GetComponent<MeshCollider>().sharedMesh = mesh;

                tile tileLink = Tile.GetComponent<tile>();
                tileLink.terrainReferenceNumber = count;
                tileLink.name = "Tile " + count;

                count++;
            }
        }
        generateCliff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateCliff()
    {
        count = 0;
        for(int i = 0; i < dataManager.xTiles; i++)
        {
            for(int j = 0; j < dataManager.zTiles; j++)
            {
                Cliff = Instantiate(cliffPrefabTile, dataManager.tiledata[count].terrainTileObjectLocation, Quaternion.identity) as GameObject;
                Object prefab2 = Resources.Load("Cliff");
                Cliff.transform.SetParent(gameObject.transform);
                Cliff.name = "Cliff " + count;
                cliff cliffLink = Cliff.GetComponent<cliff>();
                cliffLink.terrainReferenceNumber = count;

                count++;
            }
        }

        Cliff.AddComponent<MeshCollider>();
    }

    void updateCliffMesh()
    {
        
    }
}
