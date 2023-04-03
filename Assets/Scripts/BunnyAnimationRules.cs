using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAnimationRules : MonoBehaviour
{
    Animator m_Animator;
    // GameObject sword;
    // public AudioClip swordSFX;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        // sword = GameObject.FindWithTag("Sword");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        m_Animator.GetComponent<Animator>().enabled = true;
        // sword.active = false;

        if (!BunnyHealth.isPlayerDead) {
            if (Input.GetKey(KeyCode.Space)) {
                PlaySomething("Jump");
            } else {
                if ((Input.GetKey("w") || Input.GetKey("a") ||  Input.GetKey("s") ||  Input.GetKey("d"))
                   && (Input.GetKey(KeyCode.LeftShift))) { 
                    PlaySomething("Run"); 
                } else if ((Input.GetKey("w") || Input.GetKey("a") ||  Input.GetKey("s") ||  Input.GetKey("d"))) {
                    PlaySomething("Walk");
                } else if ((Input.GetKey(KeyCode.Alpha1) && (BunnyHeal.healTimes > 0) && (!BunnyInvisible.isInvisible))) {
                    PlaySomething("Spin");
                } else if ((Input.GetKey(KeyCode.Alpha3))) {
                    // sword.active = true; 
                    // AudioSource.PlayClipAtPoint(swordSFX, Camera.main.transform.position);
                    PlaySomething("Clicked");
                }
                else {
                    PlaySomething("Idle A");
                }
            }        
        } else  {
            PlaySomething("Death");
        }
        
    }

    // Play the needed animation. 
	public void PlaySomething(string s) {
		m_Animator.Play(s);
	}
}
