using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int amountofEnemies;
    [SerializeField] private int ork;
    [SerializeField] private int dog;
    [SerializeField] private int troll;
    public List<GameObject> enemyList = new List<GameObject>();

    void Start ()
    {
        Create();
    }

    void Update()
    {
    }
    public void Check(GameObject enemy)
    {
        bool dDead = transform.gameObject.GetComponent<EnemyHealth>().dead;
        if (dDead)
        {
            enemyList.Remove(enemy);
        }
    }

    void Create()
    {
        ork = amountofEnemies / 10 * 6;
        dog = amountofEnemies / 10 * 3;
        troll = amountofEnemies / 10 * 1;

        if (enemyList.Count < amountofEnemies)
        {
            for (int i = 0; i < ork; i++)
            {
                enemyList.Add(Instantiate(enemies[0]));
            }
            for (int i = 0; i < dog; i++)
            {
                enemyList.Add(Instantiate(enemies[1]));
            }
            for (int i = 0; i < troll; i++)
            {
                enemyList.Add(Instantiate(enemies[2]));
            }
        }
    }
}
