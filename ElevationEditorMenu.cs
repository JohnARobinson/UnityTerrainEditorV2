using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElevationEditorMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tileName;
    [SerializeField] private TextMeshProUGUI xPos;
    [SerializeField] private TextMeshProUGUI yPos;
    [SerializeField] private TextMeshProUGUI zPos;
    [SerializeField] private TextMeshProUGUI warning;
    [SerializeField] private Toggle cliffToggle;

    [SerializeField] private Button raiseTerrain;
    [SerializeField] private Button lowerTerrain;
    [SerializeField] private Button maintainTerrain;
    [SerializeField] private Button flattenTerrain;
    public MapTileData dataManager;
    meshManager meshManager;
    TileMouseDetector tileSelection;
    tile tile;
    int referenceNumber;
    int prevReferenceNumber;
    public float amount;
    public float prevAmount;
    float highestY;
    float highestYPrev;
    bool cliffBool;
    /*
    7 elevation levels
    30,20,10,0,-10,-20,-30

    */

    void Start()
    {
        meshManager = GameObject.FindGameObjectWithTag("MeshManager").GetComponent<meshManager>();
        dataManager = GameObject.FindGameObjectWithTag("TerrainData").GetComponent<MapTileData>();
        tileSelection = GameObject.FindGameObjectWithTag("MouseDetection").GetComponent<TileMouseDetector>();

        Button btn1 = raiseTerrain.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickRaiseTerrain);
        Button btn2 = lowerTerrain.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickLowerTerrain);
        Button btn3 = maintainTerrain.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClickMaintainTerrain);
        Button btn4 = flattenTerrain.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClickFlattenTerrain);
        Toggle toggle1 = cliffToggle.GetComponent<Toggle>();
        toggle1.onValueChanged.AddListener(delegate {
                CliffToggleValueChanged(toggle1);
            });

        
    }

    // Update is called once per frame
    void Update()
    {

        //xPos.text = "X: " + tileSelection.selectedTilePosition.x.ToString();
        xPos.text = "X: " + dataManager.tiledata[referenceNumber].terrainTileObjectLocation.x.ToString();
        //yPos.text = "Y: " + tileSelection.selectedTilePosition.y.ToString();
        yPos.text = "Y: " + highestY;
        //zPos.text = "Z: " + tileSelection.selectedTilePosition.z.ToString();
        zPos.text = "Z: " + dataManager.tiledata[referenceNumber].terrainTileObjectLocation.z.ToString();

        if(tileSelection.tileHit == true)
        {
            //tile = tileSelection.selectedTile.GetComponent<tile>();
            referenceNumber = tileSelection.selectedTileReferenceNumber;

            if(referenceNumber == prevReferenceNumber)
            {
                highestY = dataManager.tiledata[referenceNumber].terrainVertices[0].y;
                if(dataManager.tiledata[referenceNumber].terrainVertices[1].y > highestY)
                {
                    highestY = dataManager.tiledata[referenceNumber].terrainVertices[1].y;
                }
                if(dataManager.tiledata[referenceNumber].terrainVertices[2].y > highestY)
                {
                    highestY = dataManager.tiledata[referenceNumber].terrainVertices[2].y;
                }
                if(dataManager.tiledata[referenceNumber].terrainVertices[3].y > highestY)
                {
                    highestY = dataManager.tiledata[referenceNumber].terrainVertices[3].y;
                }
                amount = highestY; 
            }
            
            if(referenceNumber != prevReferenceNumber)
            {
                highestYPrev = dataManager.tiledata[prevReferenceNumber].terrainVertices[0].y;
                if(dataManager.tiledata[prevReferenceNumber].terrainVertices[1].y > highestYPrev)
                {
                    highestYPrev = dataManager.tiledata[prevReferenceNumber].terrainVertices[1].y;
                }
                if(dataManager.tiledata[prevReferenceNumber].terrainVertices[2].y > highestYPrev)
                {
                    highestYPrev = dataManager.tiledata[prevReferenceNumber].terrainVertices[2].y;
                }
                if(dataManager.tiledata[prevReferenceNumber].terrainVertices[3].y > highestYPrev)
                {
                    highestYPrev = dataManager.tiledata[prevReferenceNumber].terrainVertices[3].y;
                }
                //amount = highestYPrev;
            }
            prevReferenceNumber = referenceNumber;
        }

        //warning update
        if(tile == null)
        {
            warning.text = "No Tile Selected";
        }
        else
        {
            warning.text = "";
        }
 
        
        
    }

    void TaskOnClickRaiseTerrain()
    {
        amount = amount + 10;
        updateTerrainMesh4Vert(amount, referenceNumber);

        if(cliffBool == false)
        {
            if(referenceNumber + 1 < dataManager.tileTotalCount)
            {
                updateTerrainMesh2Vert(amount, 0, 3, referenceNumber + 1);
            }
            if(referenceNumber + dataManager.xTiles < dataManager.tileTotalCount)
            {
                updateTerrainMesh2Vert(amount, 0, 1, referenceNumber + dataManager.xTiles);
                updateTerrainMesh1CornerVert(amount, 1, referenceNumber + dataManager.xTiles - 1);
                updateTerrainMesh1CornerVert(amount, 0, referenceNumber + dataManager.xTiles + 1);
            }
            if(referenceNumber - 1 >= 0)
            {
                updateTerrainMesh2Vert(amount, 1, 2, referenceNumber - 1);
            }
            if(referenceNumber - dataManager.xTiles >= 0)
            {
                updateTerrainMesh2Vert(amount, 2, 3, referenceNumber - dataManager.xTiles);
                updateTerrainMesh1CornerVert(amount, 3, referenceNumber - dataManager.xTiles + 1);
                updateTerrainMesh1CornerVert(amount, 2, referenceNumber - dataManager.xTiles - 1);
            }
        }
    }

    void TaskOnClickLowerTerrain()
    {
        amount = amount - 10;
        
        updateTerrainMesh4Vert(amount, referenceNumber);
        if(cliffBool == false)
        {
            if(referenceNumber + 1 < dataManager.tileTotalCount)
            {
                updateTerrainMesh2Vert(amount, 0, 3, referenceNumber + 1);
            }
            if(referenceNumber + dataManager.xTiles < dataManager.tileTotalCount)
            {
                updateTerrainMesh2Vert(amount, 0, 1, referenceNumber + dataManager.xTiles);
                updateTerrainMesh1CornerVert(amount, 1, referenceNumber + dataManager.xTiles - 1);
                updateTerrainMesh1CornerVert(amount, 0, referenceNumber + dataManager.xTiles + 1);
            }
            if(referenceNumber - 1 >= 0)
            {
                updateTerrainMesh2Vert(amount, 1, 2, referenceNumber - 1);
            }
            if(referenceNumber - dataManager.xTiles >= 0)
            {
                updateTerrainMesh2Vert(amount, 2, 3, referenceNumber - dataManager.xTiles);
                updateTerrainMesh1CornerVert(amount, 3, referenceNumber - dataManager.xTiles + 1);
                updateTerrainMesh1CornerVert(amount, 2, referenceNumber - dataManager.xTiles - 1);
            }
        }

    }

    void TaskOnClickMaintainTerrain()
    {
        updateTerrainMesh4Vert(highestYPrev, referenceNumber);
        if(cliffBool == false)
        {
            if(referenceNumber + 1 < dataManager.tileTotalCount)
            {
                updateTerrainMesh2Vert(highestYPrev, 0, 3, referenceNumber + 1);
            }
            if(referenceNumber + dataManager.xTiles < dataManager.tileTotalCount)
            {
                updateTerrainMesh2Vert(highestYPrev, 0, 1, referenceNumber + dataManager.xTiles);
                updateTerrainMesh1CornerVert(highestYPrev, 1, referenceNumber + dataManager.xTiles - 1);
                updateTerrainMesh1CornerVert(highestYPrev, 0, referenceNumber + dataManager.xTiles + 1);
            }
            if(referenceNumber - 1 >= 0)
            {
                updateTerrainMesh2Vert(highestYPrev, 1, 2, referenceNumber - 1);
            }
            if(referenceNumber - dataManager.xTiles >= 0)
            {
                updateTerrainMesh2Vert(highestYPrev, 2, 3, referenceNumber - dataManager.xTiles);
                updateTerrainMesh1CornerVert(highestYPrev, 3, referenceNumber - dataManager.xTiles + 1);
                updateTerrainMesh1CornerVert(highestYPrev, 2, referenceNumber - dataManager.xTiles - 1);
            }
        }

    }

    void TaskOnClickFlattenTerrain()
    {
        amount = 0;
        
        updateTerrainMesh4Vert(amount, referenceNumber);

        if(referenceNumber + 1 < dataManager.tileTotalCount)
        {
            updateTerrainMesh2Vert(amount, 0, 3, referenceNumber + 1);
        }
        if(referenceNumber + dataManager.xTiles < dataManager.tileTotalCount)
        {
            updateTerrainMesh2Vert(amount, 0, 1, referenceNumber + dataManager.xTiles);
            updateTerrainMesh1CornerVert(amount, 1, referenceNumber + dataManager.xTiles - 1);
            updateTerrainMesh1CornerVert(amount, 0, referenceNumber + dataManager.xTiles + 1);
        }
        if(referenceNumber - 1 >= 0)
        {
            updateTerrainMesh2Vert(amount, 1, 2, referenceNumber - 1);
        }
        if(referenceNumber - dataManager.xTiles >= 0)
        {
            updateTerrainMesh2Vert(amount, 2, 3, referenceNumber - dataManager.xTiles);
            updateTerrainMesh1CornerVert(amount, 3, referenceNumber - dataManager.xTiles + 1);
            updateTerrainMesh1CornerVert(amount, 2, referenceNumber - dataManager.xTiles - 1);
        }
    }
    void CliffToggleValueChanged(Toggle toggle)
    {
        if(toggle.isOn)
        {
            cliffBool = true;
        }
        else{
            cliffBool = false;
        }
    }
    
    public void updateTerrainMesh4Vert(float amount, int tileReferenceNumber)
    {
        dataManager.tiledata[tileReferenceNumber].terrainVertices[0] = new Vector3(0,amount,0);
        dataManager.tiledata[tileReferenceNumber].terrainVertices[1] = new Vector3(0,amount,dataManager.tileSize);
        dataManager.tiledata[tileReferenceNumber].terrainVertices[2] = new Vector3(dataManager.tileSize,amount,dataManager.tileSize);
        dataManager.tiledata[tileReferenceNumber].terrainVertices[3] = new Vector3(dataManager.tileSize,amount,0);


    }
    //0 bottom left
    //1 top left
    //2 top right
    //3 bottom right
    public void updateTerrainMesh1CornerVert(float amount, int vert, int tileReferenceNumber)
    {

        if(vert == 0)
        {
            dataManager.tiledata[tileReferenceNumber].terrainVertices[0] = new Vector3(0,amount,0);
        }
        if(vert == 1)
        {
            dataManager.tiledata[tileReferenceNumber].terrainVertices[1] = new Vector3(0,amount,dataManager.tileSize);
        }
        if(vert == 2)
        {
            dataManager.tiledata[tileReferenceNumber].terrainVertices[2] = new Vector3(dataManager.tileSize,amount,dataManager.tileSize);
        }
        if(vert == 3)
        {
            dataManager.tiledata[tileReferenceNumber].terrainVertices[3]= new Vector3(dataManager.tileSize,amount,0);
        }
    }
    //top vert 1,2
    //left vert 0,1
    //right vert 2,3
    //bottom vert 0,3
    public void updateTerrainMesh2Vert(float amount, int vert1, int vert2, int tileReferenceNumber)
    {
        if(vert1 == 1 && vert2 == 2)
        {
            dataManager.tiledata[tileReferenceNumber].terrainVertices[1] = new Vector3(0,amount,dataManager.tileSize);
            dataManager.tiledata[tileReferenceNumber].terrainVertices[2] = new Vector3(dataManager.tileSize,amount,dataManager.tileSize);
        }
        if(vert1 == 0 && vert2 == 1)
        {
            dataManager.tiledata[tileReferenceNumber].terrainVertices[0] = new Vector3(0,amount,0);
            dataManager.tiledata[tileReferenceNumber].terrainVertices[1] = new Vector3(0,amount,dataManager.tileSize);
        }
        if(vert1 == 2 && vert2 == 3)
        {
            dataManager.tiledata[tileReferenceNumber].terrainVertices[2] = new Vector3(dataManager.tileSize,amount,dataManager.tileSize);
            dataManager.tiledata[tileReferenceNumber].terrainVertices[3] = new Vector3(dataManager.tileSize,amount,0);
        }
        if(vert1 == 0 && vert2 == 3)
        {
            dataManager.tiledata[tileReferenceNumber].terrainVertices[0] = new Vector3(0,amount,0);
            dataManager.tiledata[tileReferenceNumber].terrainVertices[3] = new Vector3(dataManager.tileSize,amount,0);
        }
    }
}
