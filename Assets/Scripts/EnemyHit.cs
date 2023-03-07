using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) {
       if (other.CompareTag("Projectile")) {
        DestroyFox();
        LevelManager.numEnemies--;
       }
    }

    void DestroyFox() {

        gameObject.SetActive(false);
        Destroy(gameObject, 0.5f);

    }
}

