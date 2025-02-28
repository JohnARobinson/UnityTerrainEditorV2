using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TerrainEditorMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tileTextureName;
    [SerializeField] private Dropdown textureDropDown;

    [SerializeField] private Image textureImage;
    [SerializeField] private Sprite grass1Image;
    [SerializeField] private Sprite grass2Image;
    [SerializeField] private Sprite  grass3Image;
    [SerializeField] private Sprite dirt1Image;
    [SerializeField] private Sprite sand1Image;
    [SerializeField] private Sprite rock1Image;

    public MapTileData dataManager;
    meshManager meshManager;
    TileMouseDetector tileSelection;
    tile tile;
    int referenceNumber;
    

    void Start()
    {
        meshManager = GameObject.FindGameObjectWithTag("MeshManager").GetComponent<meshManager>();
        dataManager = GameObject.FindGameObjectWithTag("TerrainData").GetComponent<MapTileData>();
        tileSelection = GameObject.FindGameObjectWithTag("MouseDetection").GetComponent<TileMouseDetector>();
        
        textureDropDown = textureDropDown.GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tileSelection.tileHit == true)
        {
            tile = tileSelection.selectedTile.GetComponent<tile>();
            referenceNumber = tile.terrainReferenceNumber;

            switch(textureDropDown.value)
            {
                case 0:
                textureImage.sprite = grass1Image;
                dataManager.tiledata[referenceNumber].tileTextureReference = 0;
                break;
                case 1:
                textureImage.sprite = grass2Image;
                dataManager.tiledata[referenceNumber].tileTextureReference = 1;
                break;
                case 2:
                textureImage.sprite = grass3Image;
                dataManager.tiledata[referenceNumber].tileTextureReference = 2;
                break;
                case 3:
                textureImage.sprite = dirt1Image;
                dataManager.tiledata[referenceNumber].tileTextureReference = 3;
                break;
                case 4:
                textureImage.sprite = sand1Image;
                dataManager.tiledata[referenceNumber].tileTextureReference = 4;
                break;
                case 5:
                textureImage.sprite = rock1Image;
                dataManager.tiledata[referenceNumber].tileTextureReference = 5;
                break;
            }
        }
        
    }
}
