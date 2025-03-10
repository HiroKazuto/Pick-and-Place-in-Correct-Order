using UnityEngine;

public class PauseScript : MonoBehaviour
{
   
    
    private bool isPaused = false;
    public Canvas PauseUI;

    
    void Start()
    {
        PauseUI.enabled = false;        
    }
    void Update()
    {
        if(TimerScript.timerIsRunning)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                if(isPaused)
                {
                    UnpauseGame();
                    CursorDisable();
                    PauseUI.enabled = false;
                }
                else
                {
                    PauseGame();
                    CursorEnable();
                    PauseUI.enabled = true;
                }
            }   
        }
        
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void CursorEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void CursorDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
}
