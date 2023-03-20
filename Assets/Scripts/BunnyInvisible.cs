using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyInvisible : MonoBehaviour
{
    public Material invisibleMaterial;
    public Material regularMaterial;

    public static bool isInvisible = false;
    public float invisibleCountDown;
    public float invisibleTimes = 300; 

    public int moveSpeed = 2;  // Units per second

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invisibleCountDown > 0) {
            invisibleCountDown -= Time.deltaTime;
        }
        else {
            invisibleCountDown = 0;
            isInvisible = false;
            //Debug.Log("Invisible? " + isInvisible);
        }


    }

    void FixedUpdate() {
        // Invisiblility 
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if ( !isInvisible) {
                invisibleTimes -= 1;
                isInvisible = true;
                invisibleCountDown = 5; //invisible for 5 seconds
                //Debug.Log("Invisible? " + isInvisible);
            }
        }

        if (isInvisible) {
            GameObject.FindGameObjectWithTag("Rabbit").GetComponent<Renderer>().material = invisibleMaterial;
        }
        else {
            GameObject.FindGameObjectWithTag("Rabbit").GetComponent<Renderer>().material = regularMaterial;
        }
    }
}
