using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    NavMeshAgent agent;
    // Health
    [SerializeField] private float health;
    public float currentHealth;
    public bool dead;
    private GameObject enemy;

    void Start()
    {
        currentHealth = health;
        enemy = gameObject;
    }
    private void Update()
    {
        isCheck();
    }

    public void isCheck()
    {
        if (currentHealth <= 0)
        {
            dead = true;
            currentHealth = 0;
            Destroy(gameObject, 10f);
            transform.gameObject.GetComponent<EnemySpawner>().Check(enemy);

        }
    }

    public void EnemyHealthCheck(float damage)
    {
        agent = this.GetComponent<NavMeshAgent>();
        currentHealth -= damage;
    }
}
