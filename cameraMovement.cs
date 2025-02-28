using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float speed = 20.0f;
    public float scrollSpeed = 40.0f;
    public float rotSpeed = 40.0f;
    float degreesPerSecond = 20;

    Vector3 pivotPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pivotPoint = new Vector3(pos.x, pos.y, pos.z+5.0f);
        

        if (Input.GetKey(KeyCode.W))
	    {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
	    {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
	    {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
	    {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
	    {
            //transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
            transform.RotateAround(pivotPoint, Vector3.up, 0.3f);
        }
        if (Input.GetKey(KeyCode.Q))
	    {
            //transform.Rotate(new Vector3(0, -degreesPerSecond, 0) * Time.deltaTime);
            transform.RotateAround(pivotPoint, Vector3.down, 0.3f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			pos.y -= scrollSpeed * Time.deltaTime;
		}
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
		{
			pos.y += scrollSpeed * Time.deltaTime;
		}
        transform.position = pos;
    }
}
