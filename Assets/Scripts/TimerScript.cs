using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timeRemaining = 10f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public Canvas TimesUpScrreen;
    public PauseScript pauseScript;
    void Start()
    {
        timerIsRunning = true;
        TimesUpScrreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if(timeRemaining > 0)
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

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Clamp(timeToDisplay, 0, Mathf.Infinity);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    void TimesUpScreenEnable()
    {
        TimesUpScrreen.enabled = true;
        pauseScript.PauseGame();
        pauseScript.CursorEnable();
    }
}
