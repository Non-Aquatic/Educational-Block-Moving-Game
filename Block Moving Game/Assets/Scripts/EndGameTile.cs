using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTile : MonoBehaviour
{
    public Transform checkUp;
    public Transform checkDown;
    public Transform checkLeft;
    public Transform checkRight;

    private TileController tileController;
    private string sceneName = "";

    void Start()
    {
        tileController = GetComponent<TileController>();
    }

    void Update()
    {
        CheckForEndGame();
    }

    private void CheckForEndGame()
    {
        if (CheckForEnd(checkUp) || CheckForEnd(checkDown) || CheckForEnd(checkLeft) || CheckForEnd(checkRight))
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
        CheckScene();
        SceneManager.LoadScene("Fact Screen");
    }

    void CheckScene()
    {
        sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("lastSceneName", sceneName);
        PlayerPrefs.Save();
    }
}
