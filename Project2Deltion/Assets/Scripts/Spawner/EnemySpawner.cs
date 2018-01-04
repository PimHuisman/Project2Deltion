using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float amountOfEnemies;
    [SerializeField] private float upEnemies;

    [SerializeField] private float ork;
    [SerializeField] private float dog;
    [SerializeField] private float troll;
    public List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private Text wave;
    [SerializeField] private int waveAmount;

    [SerializeField] private float test1;
    [SerializeField] private float test2;
    [SerializeField] private float test3;


    void Start ()
    {
        Create();
    }

    void Update()
    {
        // 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            enemyList.RemoveAt(0);
        }
        // test
        if (Input.GetKeyDown(KeyCode.P))
        {
            test1 = Mathf.RoundToInt((test1 / 10) * 6);
            test2 = Mathf.RoundToInt((test2 / 10) * 3);
            test3 = Mathf.RoundToInt((test3 / 10) * 1);
        }

        wave.text = ("Wave" + "/" + waveAmount);

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                enemyList.RemoveAt(i);
            }
        }
        if (enemyList.Count == 0)
        {
            waveAmount++;
            Create();
        }
    }

    void Create()
    {
        if (waveAmount > 0)
        {
            amountOfEnemies =Mathf.RoundToInt(amountOfEnemies + upEnemies);
        }

        if (enemyList.Count < amountOfEnemies)
        {
            ork = Mathf.RoundToInt(amountOfEnemies / 10 * 6);
            dog = Mathf.RoundToInt(amountOfEnemies / 10 * 3);
            troll = Mathf.RoundToInt(amountOfEnemies / 10 * 1);

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
