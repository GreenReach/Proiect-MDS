using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goToLeaderboards : MonoBehaviour {

    public Button b;

    // Setez fucntia butonului
	void Start () {
        b.onClick.AddListener(open);
	}
	
    // Daca butonul este apasat se vor incarca Leaderboard-urile
    public void open()
    {
        SceneManager.LoadScene("Leaderbord");
    }
}
