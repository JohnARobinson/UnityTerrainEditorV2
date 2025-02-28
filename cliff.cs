using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cliff : MonoBehaviour
{
    public MapTileData dataManager;
    public meshManager meshManager;
    public int terrainReferenceNumber;
    public int textureAssignment;
    //cliff tile mesh data
    //*********************************************
    bool[] cliffData;
    Mesh mesh;
    public Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;
    //*********************************************

    public Material cliff1;
    void Start()
    {
        dataManager = GameObject.FindGameObjectWithTag("TerrainData").GetComponent<MapTileData>();
        meshManager = GameObject.FindGameObjectWithTag("MeshManager").GetComponent<meshManager>();

        gameObject.GetComponent<MeshRenderer>().material = cliff1;

        //intialize cliff data
        cliffData = new bool[4];
        cliffData[0] = dataManager.tiledata[terrainReferenceNumber].cliffReference[0];
        cliffData[1] = dataManager.tiledata[terrainReferenceNumber].cliffReference[1];
        cliffData[2] = dataManager.tiledata[terrainReferenceNumber].cliffReference[2];
        cliffData[3] = dataManager.tiledata[terrainReferenceNumber].cliffReference[3];

        if(terrainReferenceNumber == 4)
        {
            for(int i = 0; i < cliffData.Length; i++)
            {
                cliffData[i] = true;
            }
            generateCliffMesh();
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(detectCliffDataDifference() == true)
        {
            clearCliffMesh();
            generateCliffMesh();
        }
    }

    bool detectCliffDataDifference()
    {
        for(int i = 0; i < cliffData.Length; i++)
        {
            if(cliffData[0] != dataManager.tiledata[terrainReferenceNumber].cliffReference[0])
            {
                return true;
            }
            if(cliffData[1] != dataManager.tiledata[terrainReferenceNumber].cliffReference[1])
            {
                return true;
            }
            if(cliffData[2] != dataManager.tiledata[terrainReferenceNumber].cliffReference[2])
            {
                return true;
            }
            if(cliffData[3] != dataManager.tiledata[terrainReferenceNumber].cliffReference[3])
            {
                return true;
            }
        }
        return false;
    }

    void generateCliffMesh()
    {
        mesh = new Mesh();
        int cliffCount = 0;
        for(int i = 0; i < cliffData.Length; i++)
        {
            if(cliffData[i] == true)
            {
                cliffCount++;
            }
        }
        if(cliffCount == 1)
        {
            vertices = new Vector3[4];
            uv =  new Vector2[4];
            triangles = new int[6];
            if(cliffData[0] == true)
            {
                vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
                vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];

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
            }
            if(cliffData[1] == true)
            {
                vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
                vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];

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
            }
            if(cliffData[2] == true)
            {
                vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];
                vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
                vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];

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
            }
            if(cliffData[3] == true)
            {
                vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];
                vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
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
            }
        }
        if(cliffCount == 2)
        {
            vertices = new Vector3[8];
            uv =  new Vector2[8];
            triangles = new int[12];
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(cliffData[i] == true && cliffData[j] == true)
                    {
                        if(i == 0)
                        {
                            vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
                            vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                            vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                            vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];

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
                        }
                        if(i == 1)
                        {
                            vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
                            vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                            vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                            vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];

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
                        }
                        if(i == 2)
                        {
                            vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];
                            vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
                            vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                            vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];

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
                        }
                        if(i == 3)
                        {
                            vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];
                            vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                            vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
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
                        }

                        if(j == 0)
                        {
                            vertices[4] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
                            vertices[5] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                            vertices[6] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                            vertices[7] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];

                            uv[4] = new Vector2(0,0);
                            uv[5] = new Vector2(0,1);
                            uv[6] = new Vector2(1,1);
                            uv[7] = new Vector2(1,0);
        
                            triangles[6] = 4;
                            triangles[7] = 5;
                            triangles[8] = 6;
                            triangles[9] = 4;
                            triangles[10] = 6;
                            triangles[11] = 7;
                        }
                        if(j == 1)
                        {
                            vertices[4] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
                            vertices[5] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                            vertices[6] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                            vertices[7] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];

                            uv[4] = new Vector2(0,0);
                            uv[5] = new Vector2(0,1);
                            uv[6] = new Vector2(1,1);
                            uv[7] = new Vector2(1,0);
        
                            triangles[6] = 4;
                            triangles[7] = 5;
                            triangles[8] = 6;
                            triangles[9] = 4;
                            triangles[10] = 6;
                            triangles[11] = 7;
                        }
                        if(j == 2)
                        {
                            vertices[4] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];
                            vertices[5] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
                            vertices[6] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                            vertices[7] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];

                            uv[4] = new Vector2(0,0);
                            uv[5] = new Vector2(0,1);
                            uv[6] = new Vector2(1,1);
                            uv[7] = new Vector2(1,0);
        
                            triangles[6] = 4;
                            triangles[7] = 5;
                            triangles[8] = 6;
                            triangles[9] = 4;
                            triangles[10] = 6;
                            triangles[11] = 7;
                        }
                        if(j == 3)
                        {
                            vertices[4] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];
                            vertices[5] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                            vertices[6] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
                            vertices[7] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];

                            uv[4] = new Vector2(0,0);
                            uv[5] = new Vector2(0,1);
                            uv[6] = new Vector2(1,1);
                            uv[7] = new Vector2(1,0);
        
                            triangles[6] = 4;
                            triangles[7] = 5;
                            triangles[8] = 6;
                            triangles[9] = 4;
                            triangles[10] = 6;
                            triangles[11] = 7;
                        }
                    }
                }
            }

        }
        if(cliffCount == 3)
        {
            vertices = new Vector3[12];
            uv =  new Vector2[12];
            triangles = new int[18];
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    for(int h = 0; h < 4; h++)
                    {
                        if(cliffData[i] == true && cliffData[j] == true && cliffData[h] == true)
                        {
                            if(i == 0)
                            {
                                vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
                                vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                                vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                                vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];

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
                            }
                            if(i == 1)
                            {
                                vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
                                vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                                vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                                vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];

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
                            }
                            if(i == 2)
                            {
                                vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];
                                vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
                                vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                                vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];

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
                            }
                            if(i == 3)
                            {
                                vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];
                                vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                                vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
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
                            }

                            if(j == 0)
                            {
                                vertices[4] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
                                vertices[5] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                                vertices[6] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                                vertices[7] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];

                                uv[4] = new Vector2(0,0);
                                uv[5] = new Vector2(0,1);
                                uv[6] = new Vector2(1,1);
                                uv[7] = new Vector2(1,0);
            
                                triangles[6] = 4;
                                triangles[7] = 5;
                                triangles[8] = 6;
                                triangles[9] = 4;
                                triangles[10] = 6;
                                triangles[11] = 7;
                            }
                            if(j == 1)
                            {
                                vertices[4] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
                                vertices[5] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                                vertices[6] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                                vertices[7] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];

                                uv[4] = new Vector2(0,0);
                                uv[5] = new Vector2(0,1);
                                uv[6] = new Vector2(1,1);
                                uv[7] = new Vector2(1,0);
            
                                triangles[6] = 4;
                                triangles[7] = 5;
                                triangles[8] = 6;
                                triangles[9] = 4;
                                triangles[10] = 6;
                                triangles[11] = 7;
                            }
                            if(j == 2)
                            {
                                vertices[4] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];
                                vertices[5] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
                                vertices[6] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                                vertices[7] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];

                                uv[4] = new Vector2(0,0);
                                uv[5] = new Vector2(0,1);
                                uv[6] = new Vector2(1,1);
                                uv[7] = new Vector2(1,0);
            
                                triangles[6] = 4;
                                triangles[7] = 5;
                                triangles[8] = 6;
                                triangles[9] = 4;
                                triangles[10] = 6;
                                triangles[11] = 7;
                            }
                            if(j == 3)
                            {
                                vertices[4] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];
                                vertices[5] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                                vertices[6] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
                                vertices[7] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];

                                uv[4] = new Vector2(0,0);
                                uv[5] = new Vector2(0,1);
                                uv[6] = new Vector2(1,1);
                                uv[7] = new Vector2(1,0);
            
                                triangles[6] = 4;
                                triangles[7] = 5;
                                triangles[8] = 6;
                                triangles[9] = 4;
                                triangles[10] = 6;
                                triangles[11] = 7;
                            }
                            if(h == 0)
                            {
                                vertices[8] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
                                vertices[9] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                                vertices[10] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                                vertices[11] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];

                                uv[8] = new Vector2(0,0);
                                uv[9] = new Vector2(0,1);
                                uv[10] = new Vector2(1,1);
                                uv[11] = new Vector2(1,0);
            
                                triangles[12] = 8;
                                triangles[13] = 9;
                                triangles[14] = 10;
                                triangles[15] = 8;
                                triangles[16] = 10;
                                triangles[17] = 11;
                            }
                            if(h == 1)
                            {
                                vertices[8] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
                                vertices[9] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                                vertices[10] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
                                vertices[11] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];

                                uv[8] = new Vector2(0,0);
                                uv[9] = new Vector2(0,1);
                                uv[10] = new Vector2(1,1);
                                uv[11] = new Vector2(1,0);
            
                                triangles[12] = 8;
                                triangles[13] = 9;
                                triangles[14] = 10;
                                triangles[15] = 8;
                                triangles[16] = 10;
                                triangles[17] = 11;
                            }
                            if(h == 2)
                            {
                                vertices[8] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];
                                vertices[9] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
                                vertices[10] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
                                vertices[11] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];

                                uv[8] = new Vector2(0,0);
                                uv[9] = new Vector2(0,1);
                                uv[10] = new Vector2(1,1);
                                uv[11] = new Vector2(1,0);
            
                                triangles[12] = 8;
                                triangles[13] = 9;
                                triangles[14] = 10;
                                triangles[15] = 8;
                                triangles[16] = 10;
                                triangles[17] = 11;
                            }
                            if(h == 3)
                            {
                                vertices[8] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];
                                vertices[9] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
                                vertices[10] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, 50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
                                vertices[11] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];

                                uv[8] = new Vector2(0,0);
                                uv[9] = new Vector2(0,1);
                                uv[10] = new Vector2(1,1);
                                uv[11] = new Vector2(1,0);
            
                                triangles[12] = 8;
                                triangles[13] = 9;
                                triangles[14] = 10;
                                triangles[15] = 8;
                                triangles[16] = 10;
                                triangles[17] = 11;
                            }
                        }
                    }
                }
            }
        }
        if(cliffCount == 4)
        {
            vertices = new Vector3[16];
            uv =  new Vector2[16];
            triangles = new int[24];
            vertices[0] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];
            vertices[1] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].y+50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
            vertices[2] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].y+50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
            vertices[3] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];

            vertices[4] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];
            vertices[5] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].y+50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
            vertices[6] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].x, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].y+50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[1].z);
            vertices[7] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[1];

            vertices[8] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];
            vertices[9] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].y+50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
            vertices[10] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].x, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].y+50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[2].z);
            vertices[11] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[2];

            vertices[12] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[0];
            vertices[13] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].x, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].y+50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[0].z);
            vertices[14] = new Vector3(dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].x, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].y+50, dataManager.tiledata[terrainReferenceNumber].terrainVertices[3].z);
            vertices[15] = dataManager.tiledata[terrainReferenceNumber].terrainVertices[3];

            uv[0] = new Vector2(0,0);
            uv[1] = new Vector2(0,1);
            uv[2] = new Vector2(1,1);
            uv[3] = new Vector2(1,0);

            uv[4] = new Vector2(0,0);
            uv[5] = new Vector2(0,1);
            uv[6] = new Vector2(1,1);
            uv[7] = new Vector2(1,0);

            uv[8] = new Vector2(0,0);
            uv[9] = new Vector2(0,1);
            uv[10] = new Vector2(1,1);
            uv[11] = new Vector2(1,0);

            uv[12] = new Vector2(0,0);
            uv[13] = new Vector2(0,1);
            uv[14] = new Vector2(1,1);
            uv[15] = new Vector2(1,0);
            
        
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
        }
        

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;

    }

    void clearCliffMesh()
    {
        mesh.Clear();
    }
}
