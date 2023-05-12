using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject WinPannel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CompleteGame();
        }
    }
    public void CompleteGame()
    {
        //Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        WinPannel.SetActive(true);
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
