using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    public float baseSpeed = 10;
    public float FastSpeed = 1000;

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey("m"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        float speed = 0;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = FastSpeed;
        }
        else
        {
            speed = baseSpeed;
        }

        Vector3 camChange = Vector3.zero;
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * speed;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * speed;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * speed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * speed;
        }

        Vector2 mouseCam = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        camChange = Vector2.Lerp(camChange, mouseCam, Time.deltaTime * 100);

        if (Input.GetKey("q"))
        {
            camChange.z  = 1;
        }
        if (Input.GetKey("e"))
        {
            camChange.z = -1;
        }

        transform.Rotate(camChange);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
