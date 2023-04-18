using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour
{
    public GameObject tutorialPanel;
    //[SerializeField] private Button closedButton;
    public static bool TutorialIsOn = false;

    //private void Awake()
    //{
    //    closedButton.onClick.AddListener(CloseTutorial);
    //}
    void Start()
    {
       if(TutorialIsOn)
        {
            Tutorial();
        }
        else
        {
            Tutorial();
        }

    }
   
    public void Tutorial()
    {
        Time.timeScale = 0;
        tutorialPanel.SetActive(true);
        TutorialIsOn = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Closing Tut");
        TutorialIsOn = false;

    }
}
