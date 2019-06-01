using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Button[] profile = new Button[3]; // profile
    public Canvas profileMenu, newProfile;  
    public InputField inputName; // numele noului profil

    private string[] info;
    private int option;

    // Profilele sunt incarcate din fisier
	void Start () {

        newProfile.enabled = false;

        // setez incarcarea profilului ales
        profile[0].onClick.AddListener(delegate { LoadGame(0); });
        profile[1].onClick.AddListener(delegate { LoadGame(1); });
        profile[2].onClick.AddListener(delegate { LoadGame(2); });

        // Numelele noului profile este citit
        var acceptor = new InputField.SubmitEvent();
        acceptor.AddListener(SubmitName);
        inputName.onEndEdit = acceptor;

        // Incarc profilele din fisier
        info = File.ReadAllLines("profiles.txt");

        profile[0].GetComponentInChildren<Text>().text = info[0] + "        Level: " + info[1];
        profile[1].GetComponentInChildren<Text>().text = info[2] + "        Level: " + info[3];
        profile[2].GetComponentInChildren<Text>().text = info[4] + "        Level: " + info[5];

    }

    // In cazul unui nou profil acesta este salvat in fisier cu numele si nivelul 1
    void SubmitName(string arg)
    {
        File.WriteAllText("player.txt", arg + "\r\n" + "1" + "\r\n" + option);

        info[option * 2] = arg;
        info[option * 2 + 1] = "1";

        File.WriteAllLines("profiles.txt", info);
        SceneManager.LoadScene("Meniu");
    }

    // Incarcarea profilului ales, daca jucatorul alege un profil gol se va initializa un nou profil cu un nume ales d ejucator, 
    // daca profilul nu este gol se va incarca la nivelul de unde a ramas
    void LoadGame(int x)
    {
        option = x;

        // daca profilul este gol jucatroul alege numele profiluli
        if (info[x * 2].Equals("None"))
        {
            newProfile.enabled = true;
            profileMenu.enabled = false;
            
        }
        // se incarca profilul ales
        else
        {
            File.WriteAllText("player.txt", info[x * 2] + "\r\n" + info[x * 2 + 1] + "\r\n" + x);
            SceneManager.LoadScene("Meniu");
        }

        
    }
}
