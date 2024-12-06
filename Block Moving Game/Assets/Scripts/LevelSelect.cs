using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button l1Button;
    public Button l2Button;
    public Button l3Button;
    public Button l4Button;
    public Button l5Button;
    public Button mainMenuButton;
    public Button quizButton;

    public Transform level1Container;
    public Transform level2Container;
    public Transform level3Container;
    public Transform level4Container;
    public Transform level5Container;

    // Each level will hold its own stars as children
    private Image[] level1Stars;
    private Image[] level2Stars;
    private Image[] level3Stars;
    private Image[] level4Stars;
    private Image[] level5Stars;
    // Start is called before the first frame update
    void Start()
    {
        l3Button.onClick.AddListener(GoToL3);
        l1Button.onClick.AddListener(GoToL1);
        l2Button.onClick.AddListener(GoToL2);
        l4Button.onClick.AddListener(GoToL4);
        l5Button.onClick.AddListener(GoToL5);
        mainMenuButton.onClick.AddListener(ReturnToMenu);
        CheckLevelProgress();

        level1Stars = level1Container.GetComponentsInChildren<Image>();
        level2Stars = level2Container.GetComponentsInChildren<Image>();
        level3Stars = level3Container.GetComponentsInChildren<Image>();
        level4Stars = level4Container.GetComponentsInChildren<Image>();
        level5Stars = level5Container.GetComponentsInChildren<Image>();
        UpdateStarsForLevel(1, level1Stars);
        UpdateStarsForLevel(2, level2Stars);
        UpdateStarsForLevel(3, level3Stars);
        UpdateStarsForLevel(4, level4Stars);
        UpdateStarsForLevel(5, level5Stars);
    }
    void CheckLevelProgress()
    {

        int maxLevelCompleted = PlayerPrefs.GetInt("MaxLevelCompleted", 0);

        l1Button.interactable = true;
        l2Button.interactable = (maxLevelCompleted >= 1);
        l3Button.interactable = (maxLevelCompleted >= 2);
        l4Button.interactable = (maxLevelCompleted >= 3);
        l5Button.interactable = (maxLevelCompleted >= 4);
        quizButton.interactable = (maxLevelCompleted >= 5);
    }
    void UpdateStarsForLevel(int levelNumber, Image[] stars)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            int starStatus = PlayerPrefs.GetInt($"Level{levelNumber}Star{i + 1}", 0);
            stars[i].color = starStatus == 1 ? Color.yellow : Color.gray;
        }
    }

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
    void GoToL4()
    {
        SceneManager.LoadScene("Level 4");
    }

    void GoToL5()
    {
        SceneManager.LoadScene("Level 5");
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();  
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level Select");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Quiz()
    {
        SceneManager.LoadScene("Quiz");
    }
}
