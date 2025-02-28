using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    //game states:

    /*
    0: game start
    1: editor state
    2: generate inital mesh mesh
    3: mesh needs to be updated
    */
    // Start is called before the first frame update
    private int state;
    void Start()
    {
        //game start
        state = 0;

        //editor mode
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int getState()
    {
        return state;
    }
    void setState(int newState)
    {
        state = newState;
    }
}
