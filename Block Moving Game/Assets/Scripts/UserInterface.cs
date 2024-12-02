using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
//using UnityEngine.UIElements;

public class UserInterface : MonoBehaviour
{
    public TMP_Text level;

    public GameObject pausePanel;
    public GameObject dimming;
    public GameObject holeFiller;
    public Button restartButton;
    public Button levelSelectButton;
    public Button mainMenuButton;
    public Button exitGameButton;
    public Button retryButton;
    public Button returnToSelectButton;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        level.text = SceneManager.GetActiveScene().name;

        pausePanel.SetActive(false);
        dimming.SetActive(false);
        holeFiller.SetActive(false);
        restartButton.onClick.AddListener(RestartLevel);
        retryButton.onClick.AddListener(RestartLevel);
        levelSelectButton.onClick.AddListener(ToLevelSelect);
        returnToSelectButton.onClick.AddListener(ToLevelSelect);
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
        dimming.SetActive(true);
        holeFiller.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        pausePanel.SetActive(false);
        dimming.SetActive(false);
        holeFiller.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level.text);
    }

    void ToLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
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
