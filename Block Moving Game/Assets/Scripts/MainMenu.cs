using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    private string sceneName = "";

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        sceneName = SceneManager.GetActiveScene().name;
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
}
