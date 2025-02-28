using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileData : MonoBehaviour
{
    public struct tileData
    {
        //tile locations
        public Vector3 terrainTileObjectLocation;
        //vertex data
        public Vector3[] terrainVertices;
        //number refer to texture
        public int tileTextureReference;
        //number refer to object on tile (rock,tree, etc...)
        public int tileObjectReference;
        //tile accessable
        public bool walkable;
        public bool cliff;
        public bool[] cliffReference;
    }

    public tileData[] tiledata;

    //coodinate array
    //x y z data
    Vector3[,] Tiles;

    //tile data array
    //number assosiating with tile texture
    //number 0-9
    //0 : grass //default
    //public int[] TileTextureData;

    //coodinates vs unity coodinates
    public int tileSize = 50;

    //number of tiles per row is 2x below variables accounting for negative numbers
    public int xTiles = 64;
    public int zTiles = 64;
    public int tileTotalCount;

    //public Vector3[] terrainTileObjectLocation;

    //public Vector3[,] terrainVertices;
    int terrainTileCount;
    private void Awake()
    {
        tileTotalCount = xTiles*zTiles;
        tiledata = new tileData[xTiles*zTiles];


        //terrainTileObjectLocation = new Vector3[xTiles*zTiles];
        terrainTileCount = 0;
        for(int x = 0; x < xTiles; x++)
        {
            for(int z = 0; z < zTiles; z++)
            {
                //terrainTileObjectLocation[terrainTileCount] = new Vector3(x*tileSize + 0, 0, z*tileSize + 0);   
                tiledata[terrainTileCount].terrainTileObjectLocation = new Vector3(x*tileSize + 0, 0, z*tileSize + 0);
                terrainTileCount++;
            }
        }

        
        //terrainVertices = new Vector3[xTiles*zTiles,4];
        //reference Number is index
        terrainTileCount = 0;

        for(int i = 0; i < xTiles; i++)
        {
            for(int j = 0; j < zTiles; j++)
            {
                tiledata[terrainTileCount].terrainVertices = new Vector3[4];
                for(int c = 0; c < 4; c++)
                {
                    
                    if(c == 0)
                    {
                        //tiledata[terrainTileCount].terrainVertices[0] = new Vector3(0,0,0);
                        tiledata[terrainTileCount].terrainVertices[0] = new Vector3(0,0,0);
                        
                    }
                    if(c == 1)
                    {
                        //terrainVertices[terrainTileCount,c] = new Vector3(0,0,tileSize);
                        tiledata[terrainTileCount].terrainVertices[1] = new Vector3(0,0,tileSize);
                    }
                    if(c == 2)
                    {
                        //terrainVertices[terrainTileCount,c] = new Vector3(tileSize,0,tileSize);
                        tiledata[terrainTileCount].terrainVertices[2] = new Vector3(tileSize,0,tileSize);
                        
                    }
                    if(c == 3)
                    {
                        //terrainVertices[terrainTileCount,c] = new Vector3(tileSize,0,0);
                        tiledata[terrainTileCount].terrainVertices[3] = new Vector3(tileSize,0,0);
                    }
                    
                }
                terrainTileCount++;
                //Debug.Log(terrainTileCount);
            }
        }

        //texture data array initialization
        //index is reference number
        //TileTextureData = new int[xTiles*zTiles];

        for(int i = 0; i < xTiles*zTiles; i++)
        {
            //TileTextureData[i] = 0;
            tiledata[i].tileTextureReference = 0;
        }


        //Terrain Object array



        //cliff reference Data
        for(int i = 0; i < xTiles*zTiles; i++)
        {
            tiledata[i].cliffReference = new bool[4];
            tiledata[i].cliffReference[0] = false;
            tiledata[i].cliffReference[1] = false;
            tiledata[i].cliffReference[2] = false;
            tiledata[i].cliffReference[3] = false;

        }

    }

    
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void cliffAnalyze()
    {
        int tileTotalCount = 0;
        int height = 0;
        for(int i = 0; i < xTiles; i++)
        {
            for(int j = 0; j < zTiles; j++)
            {
                if(tiledata[tileTotalCount].cliff == true)
                {
                    //if(tiledata[tileTotalCount].terrainVertices[0].y != )
                }
                tileTotalCount++;
            }
        }
    }
}
