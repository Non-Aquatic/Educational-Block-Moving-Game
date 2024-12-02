using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Time limit for the level
    public float timeLimit = 300f;  // Default 5 minutes
    public float timeRemaining;
    private bool isTimerRunning = true;
    public GameObject timesObject;
    public GameObject dimming;
    public Button restartButton;
    public Button levelSelectButton;
    // Event that can be hooked up to UI or other systems
    public delegate void TimerEvent();
    public static event TimerEvent OnTimeUp;

    public TextMeshProUGUI timeDisplay;

    void Start()
    {
        timesObject.SetActive(false);
        dimming.SetActive(false);
        restartButton.onClick.AddListener(RestartLevel);
        levelSelectButton.onClick.AddListener(ToLevelSelect);
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
        timesObject.SetActive(true);
        dimming.SetActive(true);
        Time.timeScale = 0f;
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
        timeRemaining += extraTime;  
    }
    void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ToLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }
}
