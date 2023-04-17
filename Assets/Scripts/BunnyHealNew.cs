using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyHealNew : MonoBehaviour
{
    public float healCountDown;
    public static float healTimes = 30; 
    public GameObject bunnyHeal;
    public int healAmount = 10;
    public AudioClip healSFX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        // Invisiblility 
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            // if (healTimes > 0 && !BunnyInvisible.isInvisible && BunnyHealth.currentHealth < 100) {
            if (healTimes > 0 && !BunnyInvisible.isInvisible && BunnyHealth.currentHealth < 100) {
                // acapaldi
                // This doesn't cover for the case where health ~97, you can heal past 100
                // Adding logic to stop this
                healTimes -= 1;
                var BunnyHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<BunnyHealthNew>();
                // BunnyHealth.Heal(healAmount);
                AudioSource.PlayClipAtPoint(healSFX, Camera.main.transform.position);
                Invoke("HealBunny", 2);
                Instantiate(bunnyHeal, transform.position, transform.rotation);
            }
        }
    }

    void HealBunny() {
        // Logic to stop overflow healing
        var BunnyHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<BunnyHealthNew>();
        if (BunnyHealth.currentHealth + healAmount > 100) {
            // If we would have overhealed, cap it.
            // E.g. invoked at 95 health should heal 5 (100 - curHealth) instead of 10 (healAmount)
            healAmount = 100 - BunnyHealth.currentHealth;
        }
        FindObjectOfType<BunnyHealthNew>().Heal(healAmount);
        // BunnyHealth.Heal(healAmount);
    }
}
