using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileDamageScript : MonoBehaviour
{
    BunnyHealth playerHealth;
    public int spellDamage = 10;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<BunnyHealth>();
        
        // transform.LookAt(player.transform);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(spellDamage);
        }
    }
}
