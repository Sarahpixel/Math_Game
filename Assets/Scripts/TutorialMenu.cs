using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    public GameObject tutorialPanel;
    public static bool GameIsPaused = false;

    void Start()
    {
        tutorialPanel.SetActive(true);
    }
    private void Update()
    {
        
    }
}
