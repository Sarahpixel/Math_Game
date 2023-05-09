using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderTitleMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void LoadGame()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("SpiderGame");
    }
    public void QuitGame()
    {
        Debug.Log("Quiting Game.....");
        Application.Quit();
    }
}
