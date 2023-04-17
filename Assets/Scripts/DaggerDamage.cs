using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerDamage : MonoBehaviour
{
    public int damageAmount = 5;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            // apply damage
            var playerHealth = other.gameObject.GetComponent<BunnyHealth>();
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
