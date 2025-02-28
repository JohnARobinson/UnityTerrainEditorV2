using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    // Start is called before the first frame update
    
    public MapTileData dataManager;
    public meshManager meshManager;
    public int terrainReferenceNumber;

    public int textureAssignment;
    //tile mesh data
    //*********************************************
    Mesh mesh;
    public Vector3[] vertices = new Vector3[4];
    int[] triangles = new int[6];
    Vector2[] uv = new Vector2[4];
    //*********************************************
    bool meshNeedUpdate = false;

    //my coordinates
    Vector3 gameCoordinates;

    //*************************
    //materials
    //0
    public Material grass1;
    //1
    public Material grass2;
    //2
    public Material grass3;
    //3
    public Material dirt1;
    //4
    public Material sand1;
    //5
    public Material rock1;

    //public Texture grassMerge;

    //public Texture dirtMerge;
    //*************************

    public enum HexDirection {
	N, E, W, S
    }

    [SerializeField]
    tile[] neighbors;

    void Start()
    {
        dataManager = GameObject.FindGameObjectWithTag("TerrainData").GetComponent<MapTileData>();
        meshManager = GameObject.FindGameObjectWithTag("MeshManager").GetComponent<meshManager>();
        
        //intialize vertex data
        vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];
        vertices[1] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
        vertices[2] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
        vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];



        //intialize cliff data
        textureAssignment = dataManager.tiledata[terrainReferenceNumber].tileTextureReference;
        updateTileTexture();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkDataManagerForElevationDataChange() == true)
        {
            updateTerrainTileMesh();
        }
        if(checkDataManagerForTextureDataChange() == true)
        {
            updateTileTexture();
        }
            
    }

    //compare 
    bool checkDataManagerForElevationDataChange()
    {
        bool status = false;
        if(vertices[0] != dataManager.tiledata[terrainReferenceNumber].terrainVertices[0])
        {
            vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];;
            status = true;
        }
        if(vertices[1] != dataManager.tiledata[terrainReferenceNumber].terrainVertices[1])
        {
            vertices[1] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
            status = true;
        }
        if(vertices[2] != dataManager.tiledata[terrainReferenceNumber].terrainVertices[2])
        {
            vertices[2] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
            status = true;
        }
        if(vertices[3] != dataManager.tiledata[terrainReferenceNumber].terrainVertices[3])
        {
            vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];
            status = true;
        }
        return status;
    }
    bool checkDataManagerForTextureDataChange()
    {
        bool status = false;
        if(textureAssignment != dataManager.tiledata[terrainReferenceNumber].tileTextureReference)
        {  
            textureAssignment = dataManager.tiledata[terrainReferenceNumber].tileTextureReference;
            status = true;
        }
        
        return status;
    }

    //update local mesh based on database
    public void updateTerrainTileMesh()
    { 
        mesh = new Mesh();

        vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];
        vertices[1] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
        vertices[2] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
        vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];

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

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    public void updateTileTexture()
    { 
        if(textureAssignment == 0)
        {
            gameObject.GetComponent<MeshRenderer>().material = grass1;
        }
        if(textureAssignment == 1)
        {
            gameObject.GetComponent<MeshRenderer>().material = grass2;
        }
        if(textureAssignment == 2)
        {
            gameObject.GetComponent<MeshRenderer>().material = grass3;
        }
        if(textureAssignment == 3)
        {
            gameObject.GetComponent<MeshRenderer>().material = dirt1;
        }
        if(textureAssignment == 4)
        {
            gameObject.GetComponent<MeshRenderer>().material = sand1;
        }
        if(textureAssignment == 5)
        {
            //gameObject.GetComponent<MeshRenderer>().material = rock1;
            rock1 = 
            gameObject.GetComponent<MeshRenderer>().material = rock1;
        }

    }


    public void updateTerrainMeshAllUp(float amount)
    {
        mesh = new Mesh();

        vertices[0] = new Vector3(0,amount,0);
        vertices[1] = new Vector3(0,amount,dataManager.tileSize);
        vertices[2] = new Vector3(dataManager.tileSize,amount,dataManager.tileSize);
        vertices[3] = new Vector3(dataManager.tileSize,amount,0);

        dataManager.tiledata[terrainReferenceNumber].terrainVertices[0] = new Vector3(0,amount,0);
        dataManager.tiledata[terrainReferenceNumber].terrainVertices[1] = new Vector3(0,amount,dataManager.tileSize);
        dataManager.tiledata[terrainReferenceNumber].terrainVertices[2] = new Vector3(dataManager.tileSize,amount,dataManager.tileSize);
        dataManager.tiledata[terrainReferenceNumber].terrainVertices[3] = new Vector3(dataManager.tileSize,amount,0);

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

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
    }
    public void updateTerrainTopMesh(float amount)
    {
        Vector3[] vertices = new Vector3[4];
        int[] triangles = new int[6];
        Vector2[] uv = new Vector2[4];

        Mesh mesh = new Mesh();

        vertices[0] = new Vector3(0,amount,0);
        vertices[1] = new Vector3(0,0,dataManager.tileSize);
        vertices[2] = new Vector3(dataManager.tileSize,0,dataManager.tileSize);
        vertices[3] = new Vector3(dataManager.tileSize,amount,0);

        dataManager.tiledata[terrainReferenceNumber].terrainVertices[0] = new Vector3(0,amount,0);
        dataManager.tiledata[terrainReferenceNumber].terrainVertices[1] = new Vector3(0,0,dataManager.tileSize);
        dataManager.tiledata[terrainReferenceNumber].terrainVertices[2] = new Vector3(dataManager.tileSize,0,dataManager.tileSize);
        dataManager.tiledata[terrainReferenceNumber].terrainVertices[3] = new Vector3(dataManager.tileSize,amount,0);

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

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
    }

}
