using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

   
    public static bool GameIsPaused = false;
    public Canvas PauseMenuUI;
    public Button resume, loadMenu, quit;

    // Adaugam Listenere fiecarui buton si dezactivam meniul
    private void Start()
    {
        resume.onClick.AddListener(Resume);
        quit.onClick.AddListener(QuitGame);
        loadMenu.onClick.AddListener(LoadMenu);
        PauseMenuUI.enabled = false;
    }

    // Dava jucatorul apasa "escape" meniul apare sau dispare in functie de starea in care este
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                 Resume();
            else
                 Pause();
        }
    }

    // Daca butonul "Resume" este apasat meniul se invhide si jocul continua
    public void Resume()
    {
        PauseMenuUI.enabled = false;
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    // Timpul jocului este setat la 0 si meniul de pauza apare
    public void Pause()
    {
        PauseMenuUI.enabled = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Intoarcere la meniu
    public void LoadMenu()
    {
        SceneManager.LoadScene("Meniu");
        Debug.Log("LOADING MENU ");
    }

    // Jocul se inchide
    public void QuitGame()
    {
        Debug.Log("QUITTING GAME ");
        Application.Quit();
    }



}