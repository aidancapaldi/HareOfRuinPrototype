using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunnyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    //public AudioClip deadSFX;
    public Slider healthSlider;

    public static bool isPlayerDead = false;

    public static int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
        isPlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            healthSlider.value = currentHealth;
        } 
        if (currentHealth <= 0) {
            PlayerDies();
        }
    }

    public void Heal(int healAmount)
    {
        // can't heal if invisible?
        if (currentHealth > 0 && !BunnyInvisible.isInvisible)
        {
            currentHealth += healAmount;
            healthSlider.value = currentHealth;
        } 
        if (currentHealth <= 0) {
            PlayerDies();
        }
    }

    void PlayerDies()
    {
        isPlayerDead = true;
        FindObjectOfType<LevelManager>().LevelLost();
    }
}
