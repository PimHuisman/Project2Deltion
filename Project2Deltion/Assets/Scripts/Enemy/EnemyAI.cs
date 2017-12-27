using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Health
    [SerializeField] private int health;
    public int currentHealth;
    //RagDoll
    [SerializeField] private GameObject[] body;
    //?!#.....
    [SerializeField] private Transform head;
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
        currentHealth = health;
    }
    void Update()
    {
        LookField();
        WalkArea();
        isAttack();
        isChasing();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            body[body.Length].transform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public void EnemyHealth(int damage)
    {
        Debug.Log(damage);
        currentHealth -= damage;
    }
    void LookField()
    {
        if(Physics.Raycast(head.position, head.forward, out look, lookLength))
        {
            if (look.collider.tag == "Player")
            {
                isChasing();
            }
        }
        Debug.DrawRay(head.position, head.forward * 20, Color.green);
    }
    void WalkArea()
    {
        
    }
    void isAttack()
    {
        //BOOL AI is attacking
        if (Physics.Raycast(head.position, head.forward, out attack, lookLength))
        {
            // -health from player
        }
            Debug.DrawRay(head.position, head.forward * 3, Color.red);
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
            if (this.point == point)
            {
                if( point > 4)
                {
                    point = 0;
                }
                point++;
            }
            agent.SetDestination(destination[point].position);
            Debug.Log(point);
        }
    }
}

