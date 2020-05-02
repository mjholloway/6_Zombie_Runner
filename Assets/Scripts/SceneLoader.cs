using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
        RestorePlayerStatus();
    }

    private static void RestorePlayerStatus()
    {
        Time.timeScale = 1;
        
        FindObjectOfType<PlayerHealth>().isAlive = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
