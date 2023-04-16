using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovementNew : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float origSpeed;
    private bool groundedPlayer;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;
    private float turnSpeed = 2.0f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        origSpeed = playerSpeed;
    }

    void Update() {

    }

    void FixedUpdate()
    {
       
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical"));

            Vector3 rotate = new Vector3(Input.GetAxis("Vertical"), 0, 0);
        
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0) {
                controller.Move(gameObject.transform.forward * (playerSpeed) * Time.deltaTime);
            } else if (Input.GetAxis("Vertical") > 0) {
               controller.Move(gameObject.transform.forward * 2 * (playerSpeed) * Time.deltaTime);
            }


            if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") < 0) {
                controller.Move(gameObject.transform.forward * (playerSpeed) * Time.deltaTime);
            } else if (Input.GetAxis("Vertical") < 0) {
               controller.Move(gameObject.transform.forward * 2 * (playerSpeed) * Time.deltaTime);
            }





            if (Input.GetKey(KeyCode.A)) {
                transform.Rotate(Vector3.up * turnSpeed);
            }
                
            if (Input.GetKey(KeyCode.D)) {
                transform.Rotate(Vector3.down * turnSpeed);
            }
                
            

            // if (move != Vector3.zero)
            // {
            //     gameObject.transform.forward = move;
            // }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
}
