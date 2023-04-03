using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public float speed = 1;
    Animator anim;
    float changeAnim = 2;
    enum State {
        Wandering,
        Still
    }
    enum WanderingState {
        Walk = 1,
        Bounce = 2,
        Eat = 3,
    }
    State state = State.Wandering;
    WanderingState currentWanderingAnim = WanderingState.Walk;
    ShopManager shopManager;
    int currentDestinationIdx = 0; // Has 2 WanderPoint children
    List<Vector3> destinations = new List<Vector3>();
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("animState", (int) WanderingState.Walk);
        shopManager = FindObjectOfType<ShopManager>();
        InvokeRepeating("PlayAnim", 3, 3);
        var wanderPt1 = transform.Find("WanderPoints/WanderPoint1").position;
        var wanderPt1Copy = new Vector3(wanderPt1.x, wanderPt1.y, wanderPt1.z);
        destinations.Add(wanderPt1Copy);
        var wanderPt2 = transform.Find("WanderPoints/WanderPoint2").position;
        var wanderPt2Copy = new Vector3(wanderPt2.x, wanderPt2.y, wanderPt2.z);
        destinations.Add(wanderPt2Copy);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Wandering)
        {
            Vector3 target = destinations[currentDestinationIdx];

            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Reset target when close enough to current wander point
            if (Vector3.Distance(transform.position, target) <= 1)
            {
                currentDestinationIdx = currentDestinationIdx == 1 ? 0 : 1;
            }
        }
    }

    void PlayAnim() {
        if (state == State.Wandering)
        {
            if (currentWanderingAnim == WanderingState.Walk) 
            {
                currentWanderingAnim = WanderingState.Bounce;
            }
            else 
            {
                currentWanderingAnim = WanderingState.Walk;
            }
            anim.SetInteger("animState", (int) currentWanderingAnim);
        }
        else
        {
            // state must be State.still
            anim.SetInteger("animState", (int) WanderingState.Eat);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            // Show player the shop
            shopManager.ShowShop();
            state = State.Still;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            // Hide the shop UI
            shopManager.HideShop();
            state = State.Wandering;
        }
    }
}
