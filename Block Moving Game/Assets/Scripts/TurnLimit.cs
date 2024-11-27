using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTurnLimit : MonoBehaviour
{
    // Maximum number of turns allowed
    public int maxTurns = 20;
    private int currentTurns = 0;

    // Event that can be hooked up to UI or other systems
    public delegate void TurnEvent();
    public static event TurnEvent OnTurnLimitExceeded;

    void Start()
    {
        currentTurns = 0;  // Initialize turn count at the start of the level
    }

    // Call this method every time the player makes a move
    public void OnPlayerMove()
    {
        currentTurns++;

        // Check if the player has exceeded the turn limit
        if (currentTurns > maxTurns)
        {
            TurnLimitExceeded();
        }
    }

    void TurnLimitExceeded()
    {
        // Trigger event and fail the level
        if (OnTurnLimitExceeded != null)
        {
            OnTurnLimitExceeded.Invoke();
        }

        // Load a fail scene, restart the level, or end game
        Debug.Log("Turn limit exceeded! You lost!");
        // Example: Restart current level (fail scenario)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Restart current level
    }

    // You can also reset the turn count if needed
    public void ResetTurnCount()
    {
        currentTurns = 0;
    }

    public int GetCurrentTurns()
    {
        return currentTurns;
    }
}
