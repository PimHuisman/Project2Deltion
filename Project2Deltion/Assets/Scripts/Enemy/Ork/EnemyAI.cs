using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{   
    //TabInspector
    [HideInInspector]
    public int toolbarTop;
    public int toolbarBottom;
    public string currentTab;
    //RagDoll
    [SerializeField] private GameObject[] body;
    [SerializeField] private GameObject ragDoll;
    //?!#.....
    [SerializeField] private Transform head;
    //WalkField
    [SerializeField] private Transform[] points;
    [SerializeField] private int destPoint;
    [SerializeField] private int random;
    NavMeshAgent agent;
    //LookRaycast
    private RaycastHit look;
    [SerializeField] private float lookLength;
    //isChasing
    public bool chasing;
    [SerializeField] private GameObject player;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    //isAttacking
    private RaycastHit attack;
    [SerializeField] private float attackLength;
    [SerializeField] private float damage;
    [SerializeField] private bool attacking;
    [SerializeField] private float attackAgain;
    private float attackTime;
    //isThinking;
    public bool senseField;
    [SerializeField] private float thinkTimer;
    [SerializeField] private float maxTimer;

    void Start()
    {
        thinkTimer = maxTimer;
        attackTime = attackAgain;
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);
        agent.speed = walkSpeed;
    }
    void Update()
    {
        isLooking();
        isAttacking();
        isThinking();
        isCheck();
    }
    void isCheck()
    {
        // Attacking ??
        if (attacking)
        {
            attackTime -= Time.deltaTime;
        }
        if (attackTime <= 0)
        {
            attacking = false;
            attackTime = attackAgain;
        }
        MeshCollider realenemy = transform.gameObject.GetComponent<MeshCollider>();
        bool dDead = transform.gameObject.GetComponent<EnemyHealth>().dead;
        if (dDead)
        {
            Destroy(realenemy);
            ragDoll.SetActive(true);
            agent.isStopped = true;
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
        bool dDead = transform.gameObject.GetComponent<EnemyHealth>().dead;
        if (chasing && !senseField && !dDead)
        {
            thinkTimer -= Time.deltaTime;
            agent.SetDestination(player.transform.position);
            if (thinkTimer <= 0)
            {
                thinkTimer = 0;
                thinkTimer = maxTimer;
                chasing = false;
                agent.speed = walkSpeed;
                agent.SetDestination(points[destPoint].position);
            }
        }
    }
    public void WalkArea()
    {
        agent = this.GetComponent<NavMeshAgent>();
        destPoint++;
        if (destPoint >= points.Length)
        {
            destPoint = 0;
        }
        agent.SetDestination(points[destPoint].position);
    }

    public void isChasing()
    {
        // Chasing Player
        agent = this.GetComponent<NavMeshAgent>();
        bool dDead = transform.gameObject.GetComponent<EnemyHealth>().dead;
        if (chasing && !dDead)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = runSpeed;
        }
    }
    void isAttacking()
    {
        // AI is attacking
        if (Physics.Raycast(head.position, head.forward, out attack, attackLength))
        {
            bool dDead = transform.gameObject.GetComponent<EnemyHealth>().dead;
            if (!dDead)
            {
                if (!attacking)
                {
                    if (attack.transform.tag == "Player")
                    {
                        attack.transform.gameObject.GetComponent<HealthManager>().Health(damage);
                        attacking = true;
                    }
                    // Optional Attacking Citizens
                }
            }
        }
            Debug.DrawRay(head.position, head.forward * 3, Color.red);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WayPoint")
        {
            WalkArea();
        }
    }

}

