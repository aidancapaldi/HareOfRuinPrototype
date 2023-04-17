using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyAI : MonoBehaviour
{
    public enum FSMStates
    {
        Idle, 
        Patrol, 
        Chase,
        Attack,
        Dead
    }

    public FSMStates currentState;
    public float chaseDistance = 10;
    public float attackDistance = 5;
    public GameObject player;
    public float enemySpeed = 5;

    public float shootRate = 2;

    GameObject[] wanderPoints;
    Vector3 nextDestination;
    Animator anim;
    float distanceToPlayer;
    float elapsedTime = 0;
    GameObject dagger;

    public int damageAmount = 7;

    int currentDestinationIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

      
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        bool e = gameObject.GetComponent<EnemyHealth>().isDead;
        if (e == true)
        {
            currentState = FSMStates.Dead;
        }

        switch (currentState)
        {
            case FSMStates.Patrol:
                UpdatePatrolState();
                break;
            case FSMStates.Chase:
                UpdateChaseState();
                break;
            case FSMStates.Attack:
                UpdateAttackState();
                break;
            case FSMStates.Dead:
                UpdateDeadState();
                break;            
        }
        elapsedTime += Time.deltaTime;

       

    }

    private void Initialize() {
        currentState = FSMStates.Patrol;

        wanderPoints = GameObject.FindGameObjectsWithTag("WanderPointMelee");
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        FindNextPoint();
    }

    void UpdatePatrolState() 
    {
        anim.SetInteger("animState", 1);
        if (Vector3.Distance(transform.position, nextDestination) < 1)
        {
            FindNextPoint();
        } else if (distanceToPlayer <= chaseDistance) {
            currentState = FSMStates.Chase;
        }
        FaceTarget(nextDestination);

        transform.position = Vector3.MoveTowards(transform.position, nextDestination,
           enemySpeed * Time.deltaTime);
    }

    void UpdateChaseState() 
    {
        if (!BunnyInvisible.isInvisible)
        {

            anim.SetInteger("animState", 2);

            nextDestination = player.transform.position;

            if (distanceToPlayer <= attackDistance)
            {
                currentState = FSMStates.Attack;
            }
            else if (distanceToPlayer > chaseDistance)
            {
                currentState = FSMStates.Patrol;
            }

            FaceTarget(nextDestination);

            transform.position = Vector3.MoveTowards(transform.position, nextDestination,
               enemySpeed * Time.deltaTime);
        }
        else
        {
            UpdatePatrolState();
        }
    }

    void UpdateAttackState() 
    {
        if (!BunnyInvisible.isInvisible)
        {

            nextDestination = player.transform.position;

            if (distanceToPlayer <= attackDistance)
            {
                currentState = FSMStates.Attack;
            }
            else if (distanceToPlayer > attackDistance && distanceToPlayer <= chaseDistance)
            {
                currentState = FSMStates.Chase;
            }
            else if (distanceToPlayer > chaseDistance)
            {
                currentState = FSMStates.Patrol;
            }

            FaceTarget(nextDestination);
            anim.SetInteger("animState", 6);
            Invoke("FallingObjects", 2);

        }
        else
        {
            UpdatePatrolState();
        }
    }

    void UpdateDeadState() 
    {
        anim.SetInteger("animState", 4);
        Destroy(gameObject, 1f);
    }


    void FindNextPoint()
    {
        nextDestination = wanderPoints[currentDestinationIndex].transform.position;
        currentDestinationIndex = (currentDestinationIndex + 1) % wanderPoints.Length;
    }

    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        directionToTarget.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10 * Time.deltaTime);
    }

    void EnemyAttackMelee()
    {
        var BunnyHealth = player.gameObject.GetComponent<BunnyHealth>();
        BunnyHealth.TakeDamage(damageAmount);
    }

    // private void OnCollisionEnter(Collision collision) 
    // {
    //     if (collision.gameObject.CompareTag("Projectile"))
    //     {
    //         currentState = FSMStates.Dead;
    //     }
    //     if (collision.gameObject.CompareTag("Sword"))
    //     {
    //         Debug.Log("Swordhit");
    //     }

    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         var BunnyHealth = collision.gameObject.GetComponent<BunnyHealth>();
    //         BunnyHealth.TakeDamage(damageAmount);
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var BunnyHealth = other.GetComponent<BunnyHealth>();
            BunnyHealth.TakeDamage(damageAmount);
        }

    }

    void FallingObjects() {

        float xMin = -20;
        float xMax = -30;
        float zMin = -3;
        float zMax = 7;

        // if(!isDead) {
        int numOfDaggers = 3;
        while (numOfDaggers > 0) {
            Vector3 daggerPosition;

            daggerPosition.x = Random.Range(xMin, xMax);
            // should appear from the ceiling
            daggerPosition.y = 5;
            daggerPosition.z = Random.Range(zMin, zMax);

            dagger.transform.position = daggerPosition;
    
            Instantiate(dagger, dagger.transform.position, dagger.transform.rotation);
            numOfDaggers = numOfDaggers - 1;

        }

        // }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //Debug.Log("Collided with " + collision.gameObject.ToString());
    //    if (EnemyHealth.isDead == true)
    //    {
    //        currentState = FSMStates.Dead;
    //    }
    //}
}

