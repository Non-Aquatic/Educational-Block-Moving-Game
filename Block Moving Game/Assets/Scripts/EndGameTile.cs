using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTile : MonoBehaviour
{
    public Transform checkUp;
    public Transform checkDown;
    public Transform checkLeft;
    public Transform checkRight;
    public Transform endGameTile;

    public Timer timer;
    public GameManager gameManager;

    private TileController tileController;
    private string sceneName = "";

    public UnityEngine.UI.Image star1;
    public UnityEngine.UI.Image star2;
    public UnityEngine.UI.Image star3;

    void Start()
    {
        tileController = GetComponent<TileController>();
        int leNum = GetCurrentLevelNumber();
        UpdateStarUI(leNum);
    }

    void Update()
    {
        CheckForEndGame();
    }

    private void CheckForEndGame()
    {
      /*  if (CheckForEnd(checkUp) || CheckForEnd(checkDown) || CheckForEnd(checkLeft) || CheckForEnd(checkRight))
        {
            EndGame();
        }*/
        if (CheckForEnd(endGameTile))
        {
            EndGame();
        }
    }

    private bool CheckForEnd(Transform checkPosition)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(checkPosition.position, checkPosition.GetComponent<BoxCollider2D>().size, 0f);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("End"))
            {
                return true;
            }
        }

        return false;
    }

    private void EndGame()
    {
        Debug.Log("Game Over! The tile has reached the End area.");
        AwardStars();
        CheckScene();
        UpdateMaxLevelCompleted();
        SceneManager.LoadScene("Fact Screen");
    }
    private void AwardStars()
    {
        int levelNumber = GetCurrentLevelNumber(); 

        float timeRemaining = timer.GetTimeRemaining();
        int movesTaken = gameManager.moveLimit;

        if (!PlayerPrefs.HasKey($"Level{levelNumber}Star1")) 
        {
            PlayerPrefs.SetInt($"Level{levelNumber}Star1", 1);  
            PlayerPrefs.Save();
        }

        if (timeRemaining >= 60 && !PlayerPrefs.HasKey($"Level{levelNumber}Star2"))
        {
            PlayerPrefs.SetInt($"Level{levelNumber}Star2", 1);
            PlayerPrefs.Save();
        }

        if (movesTaken >= 5 && !PlayerPrefs.HasKey($"Level{levelNumber}Star3"))
        {
            PlayerPrefs.SetInt($"Level{levelNumber}Star3", 1);
            PlayerPrefs.Save();
        }

        UpdateStarUI(levelNumber);
    }

    private void UpdateStarUI(int levelNumber)
    {
        star1.color = PlayerPrefs.GetInt($"Level{levelNumber}Star1", 0) == 1 ? Color.yellow : Color.gray;
        star2.color = PlayerPrefs.GetInt($"Level{levelNumber}Star2", 0) == 1 ? Color.yellow : Color.gray;
        star3.color = PlayerPrefs.GetInt($"Level{levelNumber}Star3", 0) == 1 ? Color.yellow : Color.gray;
    }
    void CheckScene()
    {
        sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("lastSceneName", sceneName);
        PlayerPrefs.Save();
    }
    private void UpdateMaxLevelCompleted()
    {
        int currentLevel = GetCurrentLevelNumber();
        int maxLevelCompleted = PlayerPrefs.GetInt("MaxLevelCompleted", 0);
        if (currentLevel > maxLevelCompleted)
        {
            PlayerPrefs.SetInt("MaxLevelCompleted", currentLevel);
            PlayerPrefs.Save();  
        }
    }

    private int GetCurrentLevelNumber()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        int levelNumber = 0;
        if (sceneName.StartsWith("Level"))
        {
            int.TryParse(sceneName.Substring(6), out levelNumber);
        }
        return levelNumber;
    }
}
