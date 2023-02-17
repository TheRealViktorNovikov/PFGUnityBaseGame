using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer;

    //patrol

    public Vector3 walkpoint;
    bool walkpointSet;
    public float walkPointRange;

    //attack

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public GameObject projectilePosition;

    //states

    public float sightRange, attackRange;
    public bool playerSightRange, playerAttackRange;

    private void Awake()
    {
        agent.GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerAttackRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);

        if (!playerSightRange && !playerAttackRange)
        {
            Patrol();
        }
        if (playerSightRange && !playerAttackRange)
        {
            Chase();
        }
        if (playerSightRange && playerAttackRange)
        {
            Attack();
        }
    }
    private void Patrol()
    {
        if (!walkpointSet)
        {
            SearchWalkPoint();
        }
        if(walkpointSet == true)
        {
            agent.SetDestination(walkpoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkpointSet= false;
        }
    }
    private void Chase()
    {

    }
    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange,walkPointRange);
        float randomZ = Random.Range(-walkPointRange,walkPointRange);
        walkpoint = new Vector3(randomX,transform.position.y,randomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, groundLayer))
        {
            walkpointSet = true;
            Debug.Log(walkpoint);
        }

    }
    private void Attack()
    {

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}

