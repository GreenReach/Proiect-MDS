using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Quit : MonoBehaviour {

    public Button button;

	// Setez actiunea butonului
	void Start () {
        button.onClick.AddListener(QuitGame);
    }

    // Inchide jocul
    private void QuitGame()
    {
        Application.Quit();
    }
}
