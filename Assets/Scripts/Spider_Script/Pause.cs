using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    //Event
    public UnityEvent GamePaused;
    public UnityEvent GameResume;
  
    private bool _IsPaused;
    private void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _IsPaused = !_IsPaused;

            if (_IsPaused)
            {
                Paused();
                GamePaused.Invoke();
            }
            else
            {
                Resume();
                GameResume.Invoke();
            }
        }
    }
    public void Resume()
    {
        _IsPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Paused()
    {
        _IsPaused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void LoadTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
