using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayGame()
    {
        SceneManager.LoadScene("Level Select");
    }
}
