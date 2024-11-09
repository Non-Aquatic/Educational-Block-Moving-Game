using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button l1Button;
    public Button l2Button;
    public Button l3Button;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        l3Button.onClick.AddListener(GoToL3);
        l1Button.onClick.AddListener(GoToL1);
        l2Button.onClick.AddListener(GoToL2);
        mainMenuButton.onClick.AddListener(ReturnToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToL3()
    {
        SceneManager.LoadScene("Level 3");
    }

    void GoToL1()
    {
        SceneManager.LoadScene("Level 1");
    }

    void GoToL2()
    {
        SceneManager.LoadScene("Level 2");
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
