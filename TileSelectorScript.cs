using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorScript : MonoBehaviour
{
    MapTileData dataManager;
    TileMouseDetector selectedTile;
    meshManager meshManager;
    public Material material;

    //Vector3 prevPosition;
    Vector3 currentPosition;

    public int selectorSize = 1;

    float xPos = 0;
    float yPos = 0.1f;
    float zPos = 0;

    float prevXPos = 0;
    float prevYPos = 0.1f;
    float prevZPos = 0;

    int tileSize;
    // Start is called before the first frame update
    void Start()
    {
        

        material = gameObject.GetComponent<MeshRenderer>().material;
        currentPosition = gameObject.transform.position;
        //Debug.Log("Selector Current Position: " + currentPosition);
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        dataManager = GameObject.FindGameObjectWithTag("TerrainData").GetComponent<MapTileData>();
        meshManager = GameObject.FindGameObjectWithTag("MeshManager").GetComponent<meshManager>();
        selectedTile = GameObject.FindGameObjectWithTag("MouseDetection").GetComponent<TileMouseDetector>();
        
        generateSelectorMesh();
    }

    void generateSelectorMesh()
    {
        Vector3[] vertices = new Vector3[16];
        int[] triangles = new int[24];

        Mesh mesh = new Mesh();

        vertices[0] = new Vector3(0,0,0);
        vertices[1] = new Vector3(0,0,dataManager.tileSize);
        vertices[2] = new Vector3(1,0,dataManager.tileSize);
        vertices[3] = new Vector3(1,0,0);

        vertices[4] = new Vector3(1,0,dataManager.tileSize);
        vertices[5] = new Vector3(dataManager.tileSize,0,dataManager.tileSize);
        vertices[6] = new Vector3(dataManager.tileSize,0,dataManager.tileSize-1);
        vertices[7] = new Vector3(1,0,dataManager.tileSize-1);

        vertices[8] = new Vector3(dataManager.tileSize,0,dataManager.tileSize-1);
        vertices[9] = new Vector3(dataManager.tileSize,0,0);
        vertices[10] = new Vector3(dataManager.tileSize-1,0,0);
        vertices[11] = new Vector3(dataManager.tileSize-1,0,dataManager.tileSize-1);

        vertices[12] = new Vector3(dataManager.tileSize-1,0,0);
        vertices[13] = new Vector3(1,0,0);
        vertices[14] = new Vector3(1,0,1);
        vertices[15] = new Vector3(dataManager.tileSize-1,0,1);
        
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        triangles[6] = 4;
        triangles[7] = 5;
        triangles[8] = 6;
        
        triangles[9] = 4;
        triangles[10] = 6;
        triangles[11] = 7;

        triangles[12] = 8;
        triangles[13] = 9;
        triangles[14] = 10;
        
        triangles[15] = 8;
        triangles[16] = 10;
        triangles[17] = 11;

        triangles[18] = 12;
        triangles[19] = 13;
        triangles[20] = 14;
        
        triangles[21] = 12;
        triangles[22] = 14;
        triangles[23] = 15;
                

        mesh.vertices = vertices;
        //mesh.uv = uv;
        mesh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh; 
    }

    void updateSelectorYPosition()
    {   
        float highestY = dataManager.tiledata[selectedTile.selectedTileReferenceNumber].terrainVertices[0].y;
        if(highestY < dataManager.tiledata[selectedTile.selectedTileReferenceNumber].terrainVertices[1].y)
        {
            highestY = dataManager.tiledata[selectedTile.selectedTileReferenceNumber].terrainVertices[1].y;
        }
        if(highestY < dataManager.tiledata[selectedTile.selectedTileReferenceNumber].terrainVertices[2].y)
        {
            highestY = dataManager.tiledata[selectedTile.selectedTileReferenceNumber].terrainVertices[2].y;
        }
        if(highestY < dataManager.tiledata[selectedTile.selectedTileReferenceNumber].terrainVertices[3].y)
        {
            highestY = dataManager.tiledata[selectedTile.selectedTileReferenceNumber].terrainVertices[3].y;
        }
        yPos = selectedTile.selectedTilePosition.y + highestY + 0.1f;

    }

    bool positionChangeChecker(float originalPosition, float newPosition)
    {
        return true;
    }


    void Update()
    {
        updateSelectorYPosition();

        if(prevYPos != yPos)
        {
            gameObject.transform.position = new Vector3(xPos, yPos, zPos);
        }

        //check position of tile
        xPos = selectedTile.selectedTilePosition.x;
        //yPos = selectedTile.selectedTilePosition.y + 0.1f;
        zPos = selectedTile.selectedTilePosition.z;
        //Debug.Log(yPos);

        prevXPos = xPos;
        prevYPos = yPos;
        prevZPos = zPos;
        //Debug.Log(prevYPos);


        if(Input.GetMouseButtonDown(0))
        {
            
            //updateSelectorYPosition();
            
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            
            gameObject.transform.position = new Vector3(xPos, yPos, zPos);
            //selectedTile.selectedTilePosition;
            //Debug.Log(yPos);
            Debug.Log("Selector Current Position: " + gameObject.transform.position);
        
        }

        

        if(selectorSize == 1)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
        if(selectorSize == 2)
        {
            gameObject.transform.localScale = new Vector3(1,1,2);
        }
        if(selectorSize == 3)
        {
            gameObject.transform.localScale = new Vector3(3,1,3);
        }
        if(selectorSize == 4)
        {
            gameObject.transform.localScale = new Vector3(2,1,4);
        }
        if(selectorSize == 5)
        {
            gameObject.transform.localScale = new Vector3(5,1,5);
        }

        

        

    }
    

    
}
