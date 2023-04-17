using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public Slider healthSlider;


    public int currentHealth;
    public int ProjectileDamage = 10;
    public int SwordDamage = 20;
    public int LaserDamage = 5;

    public bool isDead = false;

    // void Awake()
    // {
    //     healthSlider = GetComponentInChildren<Slider>();
    // }

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;

    }


    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            healthSlider.value = currentHealth;
        }
        else if (currentHealth <= 0)
        {
            //dead
            isDead = true;
        }
    }



    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with " + collision.gameObject.ToString());
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(ProjectileDamage);
        }
        if(collision.gameObject.CompareTag("Sword"))
        {
            TakeDamage(SwordDamage);

        }
        if(collision.gameObject.CompareTag("Laser"))
        {
            TakeDamage(LaserDamage);


        }
    }

    public void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Projectile"))
            {
                TakeDamage(ProjectileDamage);
            }
            if (other.gameObject.CompareTag("Sword"))
            {
                TakeDamage(SwordDamage);
            }
            if(other.gameObject.CompareTag("Laser"))
            {
                TakeDamage(LaserDamage);

            }
    }



}

