using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    public float cam_offset, y_height, x, z;
    public GameObject camera;
    public GameObject bullet;
    public GameObject sound1;
    public GameObject sound2;
    public Transform bulletSpawnLeft, bulletSpawnRight;
    public float throwSpeed;
    public bool paused;

	// Use this for initialization
	void Start () {
        y_height = camera.transform.position.y;
        cam_offset = 0.0f;
        throwSpeed = 20.0f;
        paused = false;
	}

    // Update is called once per frame
    void Update() {
        if (!paused)
        {
            updatePlayerControls();
        }
    }

    void updatePlayerControls()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;


        transform.Translate(0, 0, z);
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
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot("Left");
            }
            if (Input.GetMouseButtonDown(1))
            {
                Shoot("Right");
            }
            if (GameObject.FindWithTag("Player").GetComponent<PlayerStats>().followers.Count > 0)
            {
                sound1.GetComponent<AudioSource>().Stop();
                sound2.GetComponent<AudioSource>().Stop();
                sound2.GetComponent<AudioSource>().Play();
            }
            else
            {
                sound1.GetComponent<AudioSource>().Stop();
                sound2.GetComponent<AudioSource>().Stop();
                sound1.GetComponent<AudioSource>().Play();
            }
        }
    }

    void Shoot(string hand)
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerStats>().removeFollower())
        {
            GameObject projectile;
            if (hand == "Left")
                projectile = Instantiate(bullet, bulletSpawnLeft.position, bulletSpawnLeft.rotation);
            else
            {
                projectile = Instantiate(bullet, bulletSpawnRight.position, bulletSpawnRight.rotation);
            }
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * throwSpeed;
            Destroy(projectile, 2.0f);
        }
    }

    public void Pause()
    {
        paused = true;
    }

    public void Unpause()
    {
        paused = false;
    }
}
