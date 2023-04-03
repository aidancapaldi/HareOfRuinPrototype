using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAnimationRules : MonoBehaviour
{
    Animator m_Animator;
    GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        sword = GameObject.FindWithTag("Sword");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        m_Animator.GetComponent<Animator>().enabled = true;
        sword.active = false;

        if (!BunnyHealth.isPlayerDead) {
            if (Input.GetKey(KeyCode.Space)) {
                //PlaySomething("Jump");
                m_Animator.SetInteger("animState", 1);
            } else {
                if ((Input.GetKey("w") || Input.GetKey("a") ||  Input.GetKey("s") ||  Input.GetKey("d"))
                   && (Input.GetKey(KeyCode.LeftShift))) { 
                    //PlaySomething("Run"); 
                    m_Animator.SetInteger("animState", 3);
                } else if ((Input.GetKey("w") || Input.GetKey("a") ||  Input.GetKey("s") ||  Input.GetKey("d"))) {
                    //PlaySomething("Walk");
                    m_Animator.SetInteger("animState", 2);
                } else if ((Input.GetKey(KeyCode.Alpha1) && (BunnyHeal.healTimes > 0) && (!BunnyInvisible.isInvisible))) {
                    //PlaySomething("Spin");
                    m_Animator.SetInteger("animState", 5);
                } else if ((Input.GetKey(KeyCode.Alpha3))) {
                    sword.active = true; 
                    //PlaySomething("Clicked");
                    m_Animator.SetInteger("animState", 4);
                }
                else {
                    //PlaySomething("Idle A");
                    m_Animator.SetInteger("animState", 0);
                }
            }        
        } else  {
            //PlaySomething("Death");
            m_Animator.SetInteger("animState", 6);
        }
        
    }

    // Play the needed animation. 
	public void PlaySomething(string s) {
		m_Animator.Play(s);
	}
}
