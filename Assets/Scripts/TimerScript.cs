using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timeRemaining = 10f;
    public static bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public Canvas TimesUpScrreen;
    public PauseScript pauseScript;
    void Start()
    {
        timerIsRunning = true;
        TimesUpScrreen.enabled = false;
    }

    
    void Update()
    {
        if(timerIsRunning)//timer
        {
            if(timeRemaining > 0)//to check if time is remaining
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time's up!");
                timeRemaining = 0;
                timerIsRunning = false;
                TimesUpScreenEnable();
            }
        }
    }

    void DisplayTime(float timeToDisplay)//to display time on UI
    {
        timeToDisplay = Mathf.Clamp(timeToDisplay, 0, Mathf.Infinity);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    void TimesUpScreenEnable()// to enable times up screen aka game over screen
    {
        TimesUpScrreen.enabled = true;
        pauseScript.PauseGame();
        pauseScript.CursorEnable();
    }
}
