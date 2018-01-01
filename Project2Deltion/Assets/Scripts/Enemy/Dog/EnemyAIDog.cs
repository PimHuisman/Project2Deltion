using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIDog : MonoBehaviour
{
    // NavMeshAgent
    NavMeshAgent agent;
    [SerializeField] private Transform player;
    //RagDoll
    [SerializeField] private GameObject[] body;
    [SerializeField] private GameObject ragDoll;
    // isAttaking
    private RaycastHit hit;
    // isThinking
    [SerializeField] private float thinkTimer;
    [SerializeField] private float maxTimer;
    [SerializeField] private float walkTimer;
    [SerializeField] private float maxWalkTimer;
    private bool thinking;
    private bool walking;

    void Start()
    {
        walkTimer = maxWalkTimer;
        thinkTimer = maxTimer;
        walking = true;
        thinking = false;
    }
    void Update()
    {
        RagDoll();
        iswalking();
        isthinking();
    }
    void RagDoll()
    {
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
    void isAttacking()
    {
        // raycast lenght for attacking 
    }
    void iswalking()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(player.position);
    }
    void isChasing()
    {
        // change speed of dog 
    }
    void isthinking()
    {
        bool dDead = transform.gameObject.GetComponent<EnemyHealth>().dead;
        if (!dDead)
        {
            if (walking)
            {
                walkTimer -= Time.deltaTime;
                {
                    if (walkTimer <= 0)
                    {
                        walking = false;
                        thinking = true;
                        agent.isStopped = true;
                        walkTimer = maxWalkTimer;
                    }
                }
            }
            if (thinking)
            {
                thinkTimer -= Time.deltaTime;

                if (thinkTimer <= 0)
                {
                    walking = true;
                    thinking = false;
                    agent.isStopped = false;
                    thinkTimer = maxTimer;
                }
            }
        }
    }
}
