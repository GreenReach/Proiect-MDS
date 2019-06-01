using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MakeLeaderboard : MonoBehaviour {

    //Stocheaz datele jucatorului
    struct player
    {
        public int level;
        public string name;
    }


    public Text leaderboard;
    public Button returnMenu;

    // Setez actiunea butonului si creez leaderboard-ul
	void Start () {

        returnMenu.onClick.AddListener(delegate {SceneManager.LoadScene("Meniu");} );

        makeLeaderboard();
    }

    // Citesc profilele jucatorilor din fisier si creez leaderboard-ul
    void makeLeaderboard()
    {
        // incarcarea profilelor
        string[] info = File.ReadAllLines("profiles.txt");

        player[] players = new player[3];

        players[0].name = info[0];
        players[0].level = Int32.Parse(info[1]);
        players[1].name = info[2];
        players[1].level = Int32.Parse(info[3]);
        players[2].name = info[4];
        players[2].level = Int32.Parse(info[5]);

        // sortare dupa scor
        for (int i = 0; i < 2; i++)
            for (int j = i + 1; j < 3; j++)
                if (players[i].level < players[j].level)
                {
                    string n = players[i].name;
                    int l = players[i].level;

                    players[i].name = players[j].name;
                    players[i].level = players[j].level;

                    players[j].name = n;
                    players[j].level = l;

                }

        // afisare
        leaderboard.text = "1st place     " + players[0].name + "     Score: " + players[0].level + "\n" +
                           "2nd place     " + players[1].name + "     Score: " + players[1].level + "\n" +
                           "3rd place     " + players[2].name + "     Score: " + players[2].level;
    }
}
