using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button tutorialButton;
    public Button l1Button;
    public Button l2Button;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton.onClick.AddListener(GoToTutorial);
        l1Button.onClick.AddListener(GoToL1);
        l2Button.onClick.AddListener(GoToL2);
        mainMenuButton.onClick.AddListener(ReturnToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToTutorial()
    {
        Debug.Log("This does nothing until we add the Tutorial Level");
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
