using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {

    public Text text;
    public PlayerScript p;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        text.text = "Health: " + p.getHP();

    }
}
