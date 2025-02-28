using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TileMouseDetector : MonoBehaviour
{
    MapTileData dataManager;
    meshManager meshManager;
    public GameObject selectedTile;
    public Vector3 selectedTilePosition;

    public bool tileHit;
    public int selectedTileReferenceNumber;
    
    //tile tile;

    void Start()
    {
        dataManager = GameObject.FindGameObjectWithTag("TerrainData").GetComponent<MapTileData>();
        meshManager = GameObject.FindGameObjectWithTag("MeshManager").GetComponent<meshManager>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Debug.Log("shooting ray");
            //Debug.Log(ray.origin);
            
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Clicked on the UI");
                tileHit = false;
            }
            else{
                //Debug.DrawRay(ray.origin, Camera.main.transform.forward * 50000000, Color.blue);
                if(Physics.Raycast(ray, out hit, float.PositiveInfinity))
                {
                    
                    //Transform objectHit = hit.transform;
                    //Debug.Log(_hit.transform.gameObject.name);
                    //Debug.Log("hit");
                    //Debug.Log(hit.transform.name);
                    //Debug.Log("Selected Tile: " + Mathf.Round(hit.transform.position.x/dataManager.tileSize) + ", " + (hit.transform.position.y/dataManager.tileSize) + ", " + hit.transform.position.z/dataManager.tileSize);
                    Debug.Log("Selected Tile: " + hit.transform.position.x + ", " + hit.transform.position.y + ", " + hit.transform.position.z);
                    //Debug.Log(hit.collider.gameObject);
                    //Debug.Log("hit");
                    selectedTile = hit.transform.gameObject;
                    selectedTilePosition = hit.transform.position;

                    GameObject hitObject = hit.collider.gameObject;
                    if (hit.collider.CompareTag("tile"))
                    {
                        tile Tile = hit.collider.gameObject.GetComponent<tile>();
                        selectedTileReferenceNumber = Tile.terrainReferenceNumber;
                        tileHit = true;
                    }
                    if (hit.collider.CompareTag("cliff"))
                    {
                        cliff Cliff = hit.collider.gameObject.GetComponent<cliff>();
                        selectedTileReferenceNumber = Cliff.terrainReferenceNumber;
                        tileHit = true;
                    }
 
                }
                else
                {
                    tileHit = false;
                    
                }
                

            }
            Debug.Log(tileHit);

            
            
        }
    }

}
