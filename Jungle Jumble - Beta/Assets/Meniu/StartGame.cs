using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public Button button;

    // Setez actiunea butonului
    private void Start()
    {
        button.onClick.AddListener(NewGame);
    }

    // Jocul este pornit de al primul nivel
    private void NewGame()
    {

        SceneManager.LoadScene("Level 1");
    }
}
