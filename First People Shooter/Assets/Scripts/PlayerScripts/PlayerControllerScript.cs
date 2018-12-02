using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    public float cam_offset, y_height, x, z;
    public GameObject camera;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float throwSpeed;
    public bool colliding;

	// Use this for initialization
	void Start () {
        y_height = camera.transform.position.y;
        cam_offset = 0.0f;
        throwSpeed = 20.0f;
        colliding = false;
	}
	
	// Update is called once per frame
	void Update () {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;


        if (!colliding)
        {
            transform.Translate(0, 0, z);
        }
        else
        {
            transform.Translate(0, 0, -z);
            colliding = false;
        }
        transform.Rotate(0, x, 0);

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
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerStats>().removeFollower())
        {
            GameObject projectile = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * throwSpeed;
            Destroy(projectile, 2.0f);
        }
    }
}
