using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class Continue_Game : MonoBehaviour {

    public Button b;

    private string[] info;

	// Se seteaza actiunea butonului si se citeste nivelul la care jucatroul a ajuns
	void Start () {
        info = File.ReadAllLines("player.txt");
        if (info[0].Equals("0"))
            Debug.Log("Adauga Jucator");
        else
            b.onClick.AddListener(delegate { continueGame(Int32.Parse(info[1])); } );
	}
	
	// Nivelul la care jucatorul a ajuns se incarca
	void continueGame(int x)
    {
        SceneManager.LoadScene("Level " + x);
    }
}
