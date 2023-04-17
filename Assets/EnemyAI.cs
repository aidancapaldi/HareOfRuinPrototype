using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
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
    
    public float attackDistance = 5;
    public float chaseDistance = 10;
    public float enemySpeed =5;
    public float speed = 3;
    public GameObject player;
    // public GameObject deadVFX;

    public GameObject teleportationHub;

    public int damageAmount = 20;
    public GameObject dagger;

    bool attack = false;
    float attackCountDown;
    bool changeAttack = false;
    float changeAttackCountDown;

    GameObject[] wanderPoints;
    Vector3 nextDestination;
    Animator anim;
    float distanceToPlayer;
    float elapsedTime = 0;

    EnemyHealth enemyHealth;
    int health;
    int currentDestinationIndex = 0;
    Transform deadTransform;
    bool isDead;

    NavMeshAgent agent;
    public Transform enemyEyes;
    public float fieldOfView = 150;

    // Start is called before the first frame update
    void Start()
    {

        wanderPoints = GameObject.FindGameObjectsWithTag("WanderPointBoss");
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        // handTip = GameObject.FindGameObjectWithTag("HandTip");

        enemyHealth = GetComponent<EnemyHealth>();
        health = enemyHealth.currentHealth;

        isDead = false;
        agent = GetComponent<NavMeshAgent>();
        Initialize();

    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
         
        health = enemyHealth.currentHealth;
        Debug.Log("HEALTH" + health);

        if (health <= 0)
        {
            currentState = FSMStates.Dead;
        }

        switch(currentState)
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

        if (attackCountDown > 0)
        {
            attackCountDown -= Time.deltaTime;
        }
        else
        {
            attackCountDown = 0;
            attack = false;
            //Debug.Log("Invisible? " + isInvisible);
        }

        if (changeAttackCountDown > 0)
        {
            changeAttackCountDown -= Time.deltaTime;
        }
        else
        {
            changeAttackCountDown = 0;
            changeAttack = false;
            //Debug.Log("Invisible? " + isInvisible);
        }
    
    }

    void OnTriggerEnter(Collider other) {
        if (!isDead)
        {
            if (other.CompareTag("Player")) {
                // apply damage
                var playerHealth = other.GetComponent<BunnyHealth>();
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

    void Initialize() {
        currentState = FSMStates.Patrol;
        FindNextPoint(); 

    }

    void UpdatePatrolState() {
        print("Patrolling");

        anim.SetInteger("animState", 1);

        agent.stoppingDistance = 0;

        agent.speed = 3.5f;


        if(Vector3.Distance(transform.position, nextDestination) < 1) {
            FindNextPoint();
        }
        else if(distanceToPlayer <= chaseDistance || IsPlayerInClearFOV()) {
            currentState = FSMStates.Chase;

        }

        FaceTarget(nextDestination);


        transform.position = Vector3.MoveTowards
            (transform.position,nextDestination, enemySpeed * Time.deltaTime);

        agent.SetDestination(nextDestination);
    }

    void UpdateChaseState() {
        print("Chasing!");
        anim.SetInteger("animState", 2);

        nextDestination = player.transform.position;

        agent.stoppingDistance = attackDistance;

        agent.speed = 5;

        if(distanceToPlayer <= attackDistance){
            currentState = FSMStates.Attack;
        }
        else if(distanceToPlayer > chaseDistance) {
            FindNextPoint();
            currentState = FSMStates.Patrol;
        }

        FaceTarget(nextDestination);
        
        agent.SetDestination(nextDestination);

        transform.position = Vector3.MoveTowards
            (transform.position, nextDestination, enemySpeed * Time.deltaTime);
    }

    void UpdateAttackState() {
        print("attack!");

        nextDestination = player.transform.position;

        if(distanceToPlayer <= attackDistance) {
            currentState = FSMStates.Attack;
        }
        else if (distanceToPlayer > attackDistance && distanceToPlayer <= chaseDistance) {
            currentState = FSMStates.Chase;
        }
        else if (distanceToPlayer > chaseDistance) {
            currentState = FSMStates.Patrol;
        }

        FaceTarget(nextDestination);
        // anim.SetInteger("animState", 3);
        
        //bounce
        // anim.SetInteger("animState", 5);
        
        
        // change attacks every 5 seconds

        // if (!changeAttack) {
        //     changeAttack = true;
        //     changeAttackCountDown = Random.Range(2, 5); 

        //     // string[] attacks = {"FallingObjects", "RollAttack", "Teleport"};
        //     string[] attacks = {"FallingObjects", "RollAttack"};
        //     string randomAttack = attacks[Random.Range(0, attacks.Length)];
        //     print(randomAttack);
        //     Invoke(randomAttack, 3);
        // }

        // attack
        Invoke("FallingObjects", 3);

    }

    void UpdateDeadState() {
        anim.SetInteger("animState", 4);
        deadTransform = gameObject.transform;
        isDead = true;

        // LevelManager.score += 1;
        print("DYING!!");

        Destroy(gameObject, 3);

        //you won the entire game

    }

    void FindNextPoint() {


        // currentDestinationIndex = (currentDestinationIndex + 1) % wanderPoints.Length;

        nextDestination = wanderPoints[currentDestinationIndex].transform.position;

        currentDestinationIndex = (currentDestinationIndex + 1) % wanderPoints.Length;

        agent.SetDestination(nextDestination);

    }

    void FaceTarget(Vector3 target) {
        Vector3 directionToTarget = (target - transform.position).normalized;
        directionToTarget.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10* Time.deltaTime);
    }

    void FallingObjects() {

        // teleportationHub.active = false;


        anim.SetInteger("animState", 6);

        float xMin = -20;
        float xMax = -30;
        float zMin = -3;
        float zMax = 7;


        if(!isDead) {


            if (!attack)
            {
                attack = true;
                attackCountDown = 5; //attack for 5 seconds
                //Debug.Log("Invisible? " + isInvisible);

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

            }
            



        }
    }

    void RollAttack() {
        // teleportationHub.active = false;

        anim.SetInteger("animState", 5);

        Vector3 scaleChange = new Vector3(Mathf.Sin(Time.time * 2) + 1, Mathf.Sin(Time.time * 2) + 1, Mathf.Sin(Time.time * 2) + 1);
 
        transform.localScale = scaleChange;

    }

    void Teleport() {
        anim.SetInteger("animState", 3);

        teleportationHub.active = true;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        Vector3 frontRayPoint = enemyEyes.position + (enemyEyes.forward * chaseDistance);
        Vector3 leftRayPoint = Quaternion.Euler(0, fieldOfView * 0.5f, 0) * frontRayPoint;
        Vector3 rightRayPoint = Quaternion.Euler(0, -fieldOfView * 0.5f, 0) * frontRayPoint;

        Debug.DrawLine(enemyEyes.position, frontRayPoint, Color.cyan);
        Debug.DrawLine(enemyEyes.position, leftRayPoint, Color.yellow);
        Debug.DrawLine(enemyEyes.position, rightRayPoint, Color.yellow);

    }

    bool IsPlayerInClearFOV() {
        RaycastHit hit;

        Vector3 distanceToPlayer = player.transform.position - enemyEyes.position;

        if(Vector3.Angle(distanceToPlayer, enemyEyes.forward) <= fieldOfView) {
            if(Physics.Raycast(enemyEyes.position, distanceToPlayer, out hit)) {
                if(hit.collider.CompareTag("Player")) {
                    print("Player in sight!");
                    return true;
                }
                return false;
            }
            return false;
        }
        return false;

    }

}

