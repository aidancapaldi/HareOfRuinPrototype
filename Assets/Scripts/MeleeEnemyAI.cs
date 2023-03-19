using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAI : MonoBehaviour
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
        anim.SetInteger("animState", 2);

        nextDestination = player.transform.position;

        if (distanceToPlayer <= attackDistance)
        {
            currentState = FSMStates.Attack;
        } else if (distanceToPlayer > chaseDistance) {
            currentState = FSMStates.Patrol;
        }

        FaceTarget(nextDestination);

        transform.position = Vector3.MoveTowards(transform.position, nextDestination,
           enemySpeed * Time.deltaTime);
    }

    void UpdateAttackState() 
    {
        nextDestination = player.transform.position;

        if (distanceToPlayer <= attackDistance)
        {
            currentState = FSMStates.Attack;
        } else if (distanceToPlayer > attackDistance && distanceToPlayer <= chaseDistance)
        {
            currentState = FSMStates.Chase;
        } else if (distanceToPlayer > chaseDistance) {
            currentState = FSMStates.Patrol;
        }

        FaceTarget(nextDestination);
        anim.SetInteger("animState", 3);
        EnemyAttackMelee();   
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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var BunnyHealth = other.GetComponent<BunnyHealth>();
            BunnyHealth.TakeDamage(damageAmount);
        }
    }
}
