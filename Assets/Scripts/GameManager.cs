﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Problem[] problems;      // list of all problems
    public int curProblem;          // current problem the player needs to solve
    public float timePerProblem;    // time allowed to answer each problem

    public float remainingTime;     // time remaining for the current problem

    public PlayerController player; // player object

    public GameObject endPanel;

    // instance
    public static GameManager instance;

    void Awake ()
    {
        // set instance to this script.
        instance = this;
    }

    void Start ()
    {
        // set the initial problem
        SetProblem(0);
    }

    void Update ()
    {
        remainingTime -= Time.deltaTime;

        // has the remaining time ran out?
        if(remainingTime <= 0.0f)
        {
            Lose();
        }
    }

    // called when the player enters a tube
    public void OnPlayerEnterTube (int tube)
    {
        // did they enter the correct tube?
        if (tube == problems[curProblem].correctTube)
            CorrectAnswer();
        else
            IncorrectAnswer();
    }

    // called when the player enters the correct tube
    void CorrectAnswer()
    {
        // is this the last problem?
        if(problems.Length - 1 == curProblem)
            Win();
        else
            SetProblem(curProblem + 1);
    }

    // called when the player enters the incorrect tube
    void IncorrectAnswer ()
    {
        player.Stun();
    }

    // sets the current problem
    void SetProblem (int problem)
    {
        curProblem = problem;
        UIManager.instance.SetProblemText(problems[curProblem]);
        remainingTime = timePerProblem;
    }

    // called when the player answers all the problems
    void Win ()
    {
        Time.timeScale = 0;
        endPanel.SetActive(true);
        //Pause.GameIsPaused = false;
        //Pause.Instance.pausePanel.SetActive(false);
        UIManager.instance.SetEndText(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


    }

    // called if the remaining time on a problem reaches 0
    void Lose ()
    {
        Time.timeScale = 0;
        endPanel.SetActive(true);
     
        //Pause.GameIsPaused = false;
        //Pause.Instance.pausePanel.SetActive(false);
        UIManager.instance.SetEndText(false);
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