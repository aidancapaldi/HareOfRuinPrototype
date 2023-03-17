using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyHeal : MonoBehaviour
{
    public float healCountDown;
    public static float healTimes = 30; 
    public GameObject bunnyHeal;
    public int healAmount = 10;


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
        if (Input.GetKeyDown(KeyCode.H)) {
            // if (healTimes > 0 && !BunnyInvisible.isInvisible && BunnyHealth.currentHealth < 100) {
            if (healTimes > 0 && !BunnyInvisible.isInvisible && BunnyHealth.currentHealth < 100) {
                healTimes -= 1;
                var BunnyHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<BunnyHealth>();
                // BunnyHealth.Heal(healAmount);
                Invoke("HealBunny", 2);
                Instantiate(bunnyHeal, transform.position, transform.rotation);
            }
        }
    }

    void HealBunny() {
        FindObjectOfType<BunnyHealth>().Heal(healAmount);;
        // BunnyHealth.Heal(healAmount);
    }
}
