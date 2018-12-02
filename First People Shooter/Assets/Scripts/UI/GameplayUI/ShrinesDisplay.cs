using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrinesDisplay : MonoBehaviour {

    public Text shrineText;
    public int shrines;
    public int shrineTotal;

	// Use this for initialization
	void Start () {
        //******get shrine count
        shrines = 0;
        shrineTotal = 6;
	}
	
	// Update is called once per frame
	void Update () {
        shrineText.text = "Shrines: " + shrines + "/" + shrineTotal;

        if(Input.GetKeyDown(KeyCode.P))
        {
            shrines++;
        }
	}
}
