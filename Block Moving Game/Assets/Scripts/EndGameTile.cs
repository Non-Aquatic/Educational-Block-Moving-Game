using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class EndGameTile : MonoBehaviour
{
    public Transform checkUp;
    public Transform checkDown;
    public Transform checkLeft;
    public Transform checkRight;

    private TileController tileController; // Reference to the TileController

    void Start()
    {
        tileController = GetComponent<TileController>();
    }

    void Update()
    {
        // Check for end game condition at all check positions
        CheckForEndGame();
    }

    private void CheckForEndGame()
    {
        // Check for "End" collider at all check positions
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
        // Code to end the game (e.g., load a game over scene or display a message)
        Debug.Log("Game Over! The tile has reached the End area.");

        // Optionally load a new scene
        // SceneManager.LoadScene("GameOverScene"); // Uncomment to load a new scene

        // Alternatively, you could just stop the game
        // Time.timeScale = 0; // Pause the game
    }
}
