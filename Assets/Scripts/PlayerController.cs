using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpAmount = 5;

    Rigidbody rb;
    //AudioSource jumpSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //jumpSFX = GetComponent<AudioSource>();

        //rb.AddForce(transform.forward * 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y < 1)
            {
                rb.AddForce(0, jumpAmount, 0, ForceMode.Impulse);
                //jumpSFX.Play();


            }
        }
    }

    private void FixedUpdate()
    {
        //if (!LevelManager.isGameOver)
        //{
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            //Debug.Log("Horizontal: " + moveHorizontal);
            //Debug.Log("Vertical: " + moveVertical);

            Vector3 forceVector = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(forceVector * speed);

           
        //}

        //else
        //{
        //    //stops the player when the game is over
        //    rb.velocity = Vector3.zero;
        //    rb.angularVelocity = Vector3.zero;
        //}

    }
}
