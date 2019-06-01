using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class PlayerName : MonoBehaviour {

    public Text txt;

    // Afisez in meniu numele profilului ales
	void Start () {
        string[] info = File.ReadAllLines("player.txt");
        txt.text = "Player: " + info[0];
	}
	

}
