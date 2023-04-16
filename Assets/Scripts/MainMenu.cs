using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{




    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("PlayerSelect");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    
}
