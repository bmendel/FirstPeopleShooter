using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GM_Script : MonoBehaviour {

    public GameObject PauseScreen;
    public bool paused;

	// Use this for initialization
	void Start () {
        PauseScreen.SetActive(false);
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
        {
            if (!paused)
                EnablePauseScreen();
            else if (paused)
                DisablePauseScreen();
        }
	}

    private void EnablePauseScreen()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        paused = true;
        Debug.Log("Pause game : " + Time.timeScale);
    }

    private void DisablePauseScreen()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        paused = false;
        Debug.Log("Unpause game : " + Time.timeScale);
    }
}
