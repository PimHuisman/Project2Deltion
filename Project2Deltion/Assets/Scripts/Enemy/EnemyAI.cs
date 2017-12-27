using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //TabInspector
    [HideInInspector]
    public int toolbarTop;
    public int toolbarBottom;
    public string currentTab;
    //Health
    [SerializeField] private int health;
    [SerializeField] private bool dead;
    public int currentHealth;
    //RagDoll
    [SerializeField] private GameObject[] body;
    //?!#.....
    [SerializeField] private Transform head;
    //WalkField
    [SerializeField] private Transform[] destination;
    [SerializeField] private int point;
    [SerializeField] private int random;
    NavMeshAgent agent;
    //LookRaycast
    private RaycastHit look;
    [SerializeField] private float lookLength;
    //isChasing
    [SerializeField] private bool chasing;
    [SerializeField] private Transform player;
    //isAttacking
    private RaycastHit attack;
    [SerializeField] private float attackLength;
    //isThinking;
    [SerializeField] private bool senseField;
    private float thinkTimer;
    [SerializeField] private float maxTimer;

    void Start()
    {
        //agent = this.GetComponent<NavMeshAgent>();
        //agent.SetDestination(destination[point].position);
        currentHealth = health;
        thinkTimer = maxTimer;
    }
    void Update()
    {
        isLooking();
        WalkArea();
        isAttack();
        isThinking();
    }
    public void EnemyHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            dead = true;
            currentHealth = 0;
            for (int i = 0; i < body.Length; i++)
            {
                body[i].transform.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
    void isLooking()
    {
        if(Physics.Raycast(head.position, head.forward, out look, lookLength))
        {
            if (look.transform.tag == "Player")
            {
                chasing = true;
                isChasing();
            }
        }
        Debug.DrawRay(head.position, head.forward * 20, Color.green);
    }
    void isThinking()
    {
        // If you are Chased but he doesnt see you in the SenseField he will Chase you for a X Amount of Seconds  
        agent = this.GetComponent<NavMeshAgent>();
        if (chasing && !senseField && !dead)
        {
            thinkTimer -= Time.deltaTime;
            agent.SetDestination(player.position);
            if (thinkTimer <= 0)
            {
                thinkTimer = 0;
                thinkTimer = maxTimer;
                chasing = false;
            }
        }
    }
    void WalkArea()
    {
        // walking to points
    }
    void isChasing()
    {
        agent = this.GetComponent<NavMeshAgent>();
        if (chasing && !dead)
        {
            agent.SetDestination(player.position);
        }
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
    // If you see Player, Enemy is Chasing
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!dead)
            {
                senseField = true;
                chasing = true;
                isChasing();
            }
        }
    }
    // If you exit the SenseField, Enemy will not chase anymore(Enemy will go to your last Position)
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            senseField = false;
        }
    }

}

