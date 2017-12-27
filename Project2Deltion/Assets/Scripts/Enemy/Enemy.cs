using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string enemyName;
    public string enemyDescription;
    public int enemyID;
    public GameObject enemyE;

    public Enemy(string name, string description, GameObject enemy, int id)
    {
        enemyName = name;
        enemyDescription = description;
        enemyID = id;
        enemyE = enemy;
    }
}
