﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private bool _isGameOver;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //&& isGameOver
        {
            // Load the first scene in the build
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    /*
    public void GameOver()
    {
        _isGameOver = true;
    }
    */
}