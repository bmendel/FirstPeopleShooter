using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GM_Script : MonoBehaviour {

    public Canvas PauseScreen;
    public GameObject Actors;

	// Use this for initialization
	void Start () {
        PauseScreen.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
        {
            EnablePauseScreen();
        }
	}

    private void EnablePauseScreen()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Debug.Log(Time.timeScale);
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log(Time.timeScale);
        }
        PauseScreen.enabled = !PauseScreen.enabled;
        Debug.Log("Pause game");
    }
}
