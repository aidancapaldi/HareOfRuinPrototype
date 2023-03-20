using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunnyHealthNew : MonoBehaviour
{
    public int startingHealth = 100;
    //public AudioClip deadSFX;
    //public Slider healthSlider;

    public static bool isPlayerDead = false;

    int currentHealth;

    public Sprite carrot100;
    public Sprite carrot80;
    public Sprite carrot60;
    public Sprite carrot40;
    public Sprite carrot20;
    public Sprite carrot0;

    GameObject CurrentHealthBar;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        //healthSlider.value = currentHealth;
        //isPlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        ControlHealthBar();
        Debug.Log("health amount: " + currentHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            //healthSlider.value = currentHealth;
        }
        if (currentHealth <= 0)
        {
            PlayerDies();
        }
    }

    void PlayerDies()
    {
        isPlayerDead = true;
        FindObjectOfType<LevelManager>().LevelLost();
    }

    public void ControlHealthBar()
    {
        CurrentHealthBar = GameObject.FindGameObjectWithTag("HealthBar");

        if (currentHealth > 80)
        {
            CurrentHealthBar.transform.GetComponent<Image>().sprite = carrot100;


        }
        else if (currentHealth > 60 && currentHealth <= 80)
        {
            CurrentHealthBar.transform.GetComponent<Image>().sprite = carrot80;

        }
        else if (currentHealth > 40 && currentHealth <= 60)
        {
            CurrentHealthBar.transform.GetComponent<Image>().sprite = carrot60;


        }
        else if (currentHealth > 20 && currentHealth <= 40)
        {
            CurrentHealthBar.transform.GetComponent<Image>().sprite = carrot40;

        }
        else if (currentHealth > 0 && currentHealth <= 20)
        {
            CurrentHealthBar.transform.GetComponent<Image>().sprite = carrot20;


        }
        else if (currentHealth == 0)
        {
            CurrentHealthBar.transform.GetComponent<Image>().sprite = carrot0;


        }

    }
}
