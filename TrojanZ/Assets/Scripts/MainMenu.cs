using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelloader = null;
    public void PlayGame()
    {
        Invoke("StartGame",2f);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void StartGame()
    {
        levelloader.LoadNextLevel();
    }
}
