using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public int next_level = 1; // nivelul urmator

    // Daca jucatorul a atins finalul nivelului atunci scorul lui este updatat si urmatorul nivel este incarcat
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {

            string[] info = File.ReadAllLines("profiles.txt");
            string[] player = File.ReadAllLines("player.txt");

            // Updatez scorul jucatroului in fisierul de profile 
            int option = Int32.Parse(player[2]);
            Debug.Log(info[option * 2 + 1]);
            int level = Int32.Parse(info[option * 2 + 1]);
            level++;
            info[option * 2 + 1] = level.ToString();

            File.WriteAllLines("profiles.txt", info);

            // Incarc scena urmatoare
            SceneManager.LoadScene("Level " + next_level);
            
        }

    }
}
