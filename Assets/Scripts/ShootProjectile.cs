using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float projectileSpeed = 100;
    public AudioClip spellSFX;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !LevelManager.isGameOver)
        {
            GameObject projectile = Instantiate(projectilePrefab,
                transform.position + transform.forward, transform.rotation);
                
            projectile.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);


            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);

            // projectile.transform.SetParent(
            //     GameObject.FindGameObjectWithTag("ProjectileParent").transform);

            AudioSource.PlayClipAtPoint(spellSFX, transform.position);
        }
    }

   
    
}

