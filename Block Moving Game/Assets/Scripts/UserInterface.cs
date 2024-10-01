using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UserInterface : MonoBehaviour
{
    public TMP_Text level;

    public GameObject pausePanel;
    public Button restartButton;
    //public Button saveGameButton;
    public Button mainMenuButton;
    public Button exitGameButton;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        level.text = SceneManager.GetActiveScene().name;

        pausePanel.SetActive(false);
        restartButton.onClick.AddListener(RestartLevel);
        //saveGameButton.onClick.AddListener(SaveGame);
        mainMenuButton.onClick.AddListener(ReturnToMenu);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(level.text);
    }

    void SaveGame()
    {
        //I'm not sure how we want to go about doing this so this is more for show atm.
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
