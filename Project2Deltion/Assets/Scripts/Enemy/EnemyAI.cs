using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //WalkField
    [SerializeField] Transform[] destination;
    [SerializeField] private int point;
    [SerializeField] private int random;
    NavMeshAgent agent;
    //AttackRayCast
    private RaycastHit attack;
    [SerializeField] private float attackLength;
    //LookRaycast
    private RaycastHit look;
    [SerializeField] private float lookLength;
    //isChasing
    [SerializeField] private bool chasing;
    [SerializeField] private Transform player;
    //isAttacking

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination[point].position);
    }
    void Update()
    {
        WalkArea();
        LookField();
        isAttack();
    }
    void LookField()
    {
        if(Physics.Raycast(transform.position, transform.forward, out look, lookLength))
        {
            if (look.collider.tag == "Player")
            {
                isChasing();
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 20, Color.green);
    }
    void WalkArea()
    {
        
    }
    void isAttack()
    {
        //BOOL AI is attacking
        if (Physics.Raycast(transform.position, transform.forward, out attack, lookLength))
        {
            // -health from player
        }
            Debug.DrawRay(transform.position, transform.forward * 3, Color.red);
    }
    void isChasing()
    {
        if (chasing)
        {
            agent.SetDestination(player.position);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Point")
        {
            agent = this.GetComponent<NavMeshAgent>();
            agent.SetDestination(destination[point].position);
            for (int i = 0; i < length; i++)
            {

            }
        }
    }
}

