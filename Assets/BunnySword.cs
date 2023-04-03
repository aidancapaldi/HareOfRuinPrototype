using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnySword : MonoBehaviour
{
    GameObject sword;
    public AudioClip swordSFX;

    // Start is called before the first frame update
    void Start()
    {
        sword = GameObject.FindWithTag("Sword");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sword.active = false;
        if ((Input.GetKey(KeyCode.Alpha3))) {
            sword.active = true; 
            AudioSource.PlayClipAtPoint(swordSFX, Camera.main.transform.position);
        }
    }
}
