using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    private string sceneName = "";

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        sceneName = SceneManager.GetActiveScene().name;
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayGame()
    {
        PlayerPrefs.SetString("lastSceneName", sceneName);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Fact Screen");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
