using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressMenu : MonoBehaviour
{
    public Text EnemiesKilledText;
    public int enemyKillNum;
    public int showEnemyKillNum;

    // Start is called before the first frame update
    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesKilledText.text = "0";

        NumEnemiesKilled();
    }

    public void NumEnemiesKilled()
    {
        if (EnemiesKilledText != null)
        {
            int showEnemyKillNum = PlayerPrefs.GetInt("enemyKillNumber", 0);

            EnemiesKilledText.text = showEnemyKillNum.ToString();
        }
    }
}
