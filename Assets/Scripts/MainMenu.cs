using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Text EnemiesKilledText;
    public int enemyKillNum;
    public int showEnemyKillNum;

    public void Start()
    {
        //EnemiesKilledText = GetComponent<Text>();
        //EnemiesKilledText.text = "0";

    }

    //public void Update()
    //{
    //    NumEnemiesKilled();

    //}



    //public void NumEnemiesKilled()
    //{
    
    //        int showEnemyKillNum = PlayerPrefs.GetInt("enemyKillNumber");
    //        EnemiesKilledText.text = showEnemyKillNum.ToString();
    //}

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
