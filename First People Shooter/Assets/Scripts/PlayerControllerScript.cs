using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    float cam_offset, y_height;
    public GameObject camera;

    public GameObject bullet;
    public Transform bulletSpawn;
    public float throwSpeed;

	// Use this for initialization
	void Start () {
        y_height = camera.transform.position.y;
        cam_offset = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;
        
        
        transform.Translate(x, 0, z);

        if (Input.GetKey(KeyCode.W) && cam_offset < 8.01f)
        {
            cam_offset += 0.05f;
            if (cam_offset > 8.0f)
            {
                cam_offset = 8.0f;
            }
        }
        else if (cam_offset > 0.0f)
        {
            cam_offset -= 0.15f;
        }

        camera.transform.position = new Vector3(camera.transform.position.x,
                                                y_height + cam_offset,
                                                camera.transform.position.z);

        //Throw follower on Left Mouse Click
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
            float step = throwSpeed * Time.deltaTime;
            GameObject instBullet = Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
            Vector3 target = Input.mousePosition;
            //target.z = transform.position.z - Camera.main.transform.position.z;
            target = Camera.main.ScreenToWorldPoint(target);
            instBullet.transform.position = Vector3.MoveTowards(bulletSpawn.position, target, step);

            Vector3 dir = this.transform.position - target;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
    }
}
