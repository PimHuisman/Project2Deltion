using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string enemyName;
    public int healthG;
    public int enemyID;

    public Enemy(string name, int health, int id)
    {
        enemyName = name;
        healthG = health;
        enemyID = id;
    }
}
