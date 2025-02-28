using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileEditorTopMenu : MonoBehaviour
{
    [SerializeField] private Button elevation;
    [SerializeField] private Button terrain;
    [SerializeField] private GameObject elevationPanel;
    [SerializeField] private GameObject terrainPanel;
    
    //0 elevation menu
    //1 terrain menu
    //2 other tbd
    int activeMenu = 0;
    void Start()
    {
        Button btn1 = elevation.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickElevation);
        Button btn2 = terrain.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickTerrain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClickElevation()
    {
        if(activeMenu != 0)
        {
            elevationPanel.SetActive(true);
            terrainPanel.SetActive(false);

            activeMenu = 0;
        }
    }

    void TaskOnClickTerrain()
    {
        if(activeMenu != 1)
        {
            elevationPanel.SetActive(false);
            terrainPanel.SetActive(true);

            activeMenu = 1;
        }
    }
}
