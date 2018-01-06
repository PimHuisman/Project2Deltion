using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    NavMeshAgent agent;
    // Health
    public float health;
    public float currentHealth;
    public bool dead;
    [SerializeField] private int points;
    [SerializeField] private int killes;
    private Transform score;
    private bool flagCheck;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreManager").transform;
        print(GameObject.FindGameObjectWithTag("ScoreManager"));
        flagCheck = true;
        currentHealth = health;
    }
    private void Update()
    {
        isCheck();;
    }

    public void isCheck()
    {
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            dead = true;
            Score();
            Destroy(gameObject, 10f);
        }
    }

    public void EnemyHealthCheck(float damage)
    {
        agent = this.GetComponent<NavMeshAgent>();
        currentHealth -= damage;
    }

    void Score()
    {
        if (flagCheck)
        {
            flagCheck = false;
            score.GetComponent<ScoreManager>().Killes(killes);
            score.GetComponent<ScoreManager>().Points(points);
        }
    }


}
