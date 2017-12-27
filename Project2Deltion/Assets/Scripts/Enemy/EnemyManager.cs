using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemy = new List<Enemy>();

    void Start()
    {
        EnemyDataBase();
    }

    public  void EnemyDataBase()
    {
        enemy.Add(new Enemy("Person", 70, 0));
        enemy.Add(new Enemy("Dog", 40, 1));
        enemy.Add(new Enemy("Giant", 200, 3));
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
