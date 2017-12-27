using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemy = new List<Enemy>();
    public GameObject[] enemyE;

    void Start()
    {
        EnemyDataBase();
    }

    public  void EnemyDataBase()
    {
        enemy.Add(new Enemy("Person", "simple attack middle hp",enemyE[0], 0));
        enemy.Add(new Enemy("Dog", "fast attack but low hp",enemyE[1], 1));
        enemy.Add(new Enemy("Giant", "slow a lot of hp",enemyE[2], 3));
    }

    public Enemy GetEnemyID(int id)
    {
        foreach(Enemy enem in enemy)
        {
            if(enem.enemyID == id)
            {
                return enem;
            }
        }
        return null;

    }
}
