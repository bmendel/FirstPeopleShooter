using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    float cam_offset, y_height;
    public GameObject camera;

	// Use this for initialization
	void Start () {
        y_height = camera.transform.position.y;
        cam_offset = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;
        

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKey(KeyCode.W) && cam_offset < 5.1f)
        {
            Debug.Log("W is pressed, cam_offset is " + cam_offset);
            cam_offset += 0.3f;
            if (cam_offset > 5.0f)
            {
                cam_offset = 5.0f;
            }
        }
        else if (cam_offset > 0.0f)
        {
            Debug.Log("W is not pressed, cam_offset is " + cam_offset);
            cam_offset -= 0.3f;
        }

        camera.transform.position = new Vector3(camera.transform.position.x,
                                                y_height + cam_offset,
                                                camera.transform.position.z);
    }
}
