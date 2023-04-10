using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void LoadGame()
    {

        Time.timeScale = 1.5f;
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Debug.Log("Quiting Game.....");
        Application.Quit();
    }
}