using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void LoadGame()
    {
        // Scene 1 == First Game Scene
        SceneManager.LoadScene(1);
    }

    public void LoadCredits()
    {
        // credits panel == true here
    }

    public void Quit()
    {
        //EditorApplication.Exit(0);
        Application.Quit();
    }
}
