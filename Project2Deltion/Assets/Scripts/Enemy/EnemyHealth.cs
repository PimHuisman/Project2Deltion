using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    NavMeshAgent agent;
    // Health
    [SerializeField] private int health;
    public int currentHealth;
    public bool dead;
    [SerializeField] private GameObject test;

    void Start()
    {
        currentHealth = health;
    }
    private void Update()
    {
        isCheck();
    }

    public void isCheck()
    {
        // Dead ??
        if (currentHealth <= 0)
        {
            dead = true;
            currentHealth = 0;
            test.GetComponent<EnemySpawner>().enemyList.Remove(gameObject);
            Destroy(gameObject, 10f);
        }
    }

    public void EnemyHealthCheck(int damage)
    {
        agent = this.GetComponent<NavMeshAgent>();
        currentHealth -= damage;
    }
}
