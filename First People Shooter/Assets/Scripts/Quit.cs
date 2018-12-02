using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    // Use this for initialization
    public void exitgame() { 
    
        Application.Quit();
        Debug.Log("Quitting");
    }
    }