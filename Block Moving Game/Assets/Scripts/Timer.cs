using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Time limit for the level
    public float timeLimit = 300f;  // Default 5 minutes
    private float timeRemaining;
    private bool isTimerRunning = true;

    // Event that can be hooked up to UI or other systems
    public delegate void TimerEvent();
    public static event TimerEvent OnTimeUp;

    public TextMeshProUGUI timeDisplay;

    void Start()
    {
        timeRemaining = timeLimit;  
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeRemaining -= Time.deltaTime;
            timeDisplay.text = Mathf.Ceil(timeRemaining).ToString() + "s left";
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isTimerRunning = false;
                TimeUp();
            }
        }
    }

    void TimeUp()
    {
        // Trigger event and fail the level
        if (OnTimeUp != null)
        {
            OnTimeUp.Invoke();
        }

        // Load a fail scene, restart the level, or end game
        Debug.Log("Time's up! You lost!");
        // Example: Load the current scene again (level fail scenario)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Restart current level
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    // You can call this to reset the timer from other scripts if needed
    public void ResetTimer()
    {
        timeRemaining = timeLimit;
        isTimerRunning = true;
    }
    public void AddTime(float extraTime)
    {
        timeRemaining += extraTime;  // Add extra time
    }
}
