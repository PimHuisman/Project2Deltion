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
        if (currentHealth <= 0)
        {
            dead = true;
            currentHealth = 0;
            Destroy(gameObject, 10f);
        }
    }

    public void EnemyHealthCheck(float damage)
    {
        agent = this.GetComponent<NavMeshAgent>();
        currentHealth -= damage;
    }
}
