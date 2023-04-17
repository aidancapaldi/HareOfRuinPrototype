using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    //calculate this from the arena given   
    public float xMin = 425;
    public float xMax = 440;
    public float zMin = 405;
    public float zMax = 417;

    public GameObject enemy;
    public float teleportTime = 3;
    public GameObject teleportParticles;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Teleport", teleportTime, teleportTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Teleport(){
        Vector3 enemyPosition;

        enemyPosition.x = Random.Range(xMin, xMax);
        // should teleport on the ground
        enemyPosition.y = enemy.transform.position.y;
        enemyPosition.z = Random.Range(zMin, zMax);

        Instantiate(teleportParticles, enemy.transform.position, enemy.transform.rotation);
        // wait half a second then appear somewhere else
        enemy.transform.position = enemyPosition;
            
    }

}
