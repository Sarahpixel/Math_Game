using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gamePanel;

  
    public static Pause Instance;
    public static bool GameIsPaused = false;
    private void Start()
    {
        Instance = this;
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                
            }
            else
            {
                Paused();
                
            }
        }


    }
    public void Resume()
    {
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);

        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void Paused()
    {
        pausePanel.SetActive(true);
        gamePanel.SetActive(false);

        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
