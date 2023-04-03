using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovementRules : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float origSpeed;
    private bool groundedPlayer;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        origSpeed = playerSpeed;
    }

    void Update() {

    }

    void FixedUpdate()
    {
        if (!BunnyHealth.isPlayerDead && !LevelManager.isGameOver) {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
            if (Input.GetKey(KeyCode.LeftShift)) {
                controller.Move(-move * Time.deltaTime * playerSpeed * 2);
            } else {
                controller.Move(-move * Time.deltaTime * playerSpeed);
            }
            

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = -move;
            }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        
    }
}
