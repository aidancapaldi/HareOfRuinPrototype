using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public float speed = 1;
    public float distance = 5;
    Animator anim;
    float changeAnim = 2;
    int currentAnim = 1;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        startPos = transform.position;
        anim.SetInteger("animState", 1);
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("PlayAnim", 3, 3);
        Vector3 newPos = transform.position;
        newPos.x = startPos.x + (Mathf.Sin(Time.time * speed) * distance);
        transform.LookAt(newPos);
        transform.position = newPos;
    }

    void PlayAnim() {
        if (currentAnim == 1) {
            currentAnim = 2;
        }
        else {
            currentAnim = 1;
        }
        anim.SetInteger("animState", currentAnim);
    }

}
