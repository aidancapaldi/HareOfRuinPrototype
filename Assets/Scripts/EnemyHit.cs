using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // private void OnTriggerEnter(Collider other) {
    //    if (other.CompareTag("Projectile") || other.CompareTag("Sword") ) {
    //     DestroyFox();
    //     LevelManager.numEnemies--;
    //    }
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Projectile") || other.CompareTag("Sword") )
    //     {
    //         DestroyFox();
    //     }
    // }

    // void DestroyFox() {

    //     //gameObject.SetActive(false);
    //     anim.SetInteger("animState", 4);
    //     Destroy(gameObject, 0.5f);
    // }
}

