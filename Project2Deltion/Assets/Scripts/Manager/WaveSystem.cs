using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    // Enemy value
    public float currentAmountOfEnemies;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float amountOfEnemies;
    [SerializeField] private float upEnemies;
    [SerializeField] private float upHealth;
    // Type enemy
    [SerializeField] private float ork;
    [SerializeField] private float dog;
    [SerializeField] private float troll;
    public List<Transform> orkSpawnPoints = new List<Transform>();
    public List<Transform> dogSpawnPoints = new List<Transform>();
    public List<Transform> trollSpawnPoints = new List<Transform>();
    // Waves
    [SerializeField] private Text wave;
    [SerializeField] private int waveAmount;
    private bool flagCheck;
    // Amount Of Enemies
    [SerializeField] Text totalEnemies;


    void Start ()
    {
        flagCheck = false;
        Create();
        waveAmount++;
        currentAmountOfEnemies = amountOfEnemies;
    }

    void Update()
    {
        // Test
        if (Input.GetKeyDown(KeyCode.P))
        {
            print(enemies[0].GetComponent<EnemyHealth>().health);
        }
        totalEnemies.text = ("Left" + "/" + currentAmountOfEnemies);
        wave.text = ("Wave" + "/" + waveAmount);
        if (currentAmountOfEnemies <= 0)
        {
            flagCheck = true;
            CheckEnemy();
        }
    }
    void CheckEnemy()
    {
        if (flagCheck)
        {
            flagCheck = false;
            amountOfEnemies += upEnemies;
            currentAmountOfEnemies = amountOfEnemies;

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyHealth>().UpEnemyHealth(upHealth);
            }

            Create();
            waveAmount++;
        }
    }

    public void EnemyCheck(float enemy)
    {
        Mathf.RoundToInt(currentAmountOfEnemies -= enemy);
    }

    void Create()
    {

        if (waveAmount > 0)
        {
            if (currentAmountOfEnemies <= 0)
            {
                amountOfEnemies = Mathf.RoundToInt(amountOfEnemies + upEnemies);
            }
        }

        Transform randomspawnOrk = orkSpawnPoints [Random.Range(0, orkSpawnPoints.Count)];
        Transform randomspawnDog = dogSpawnPoints [Random.Range(0, dogSpawnPoints.Count)];
        Transform randomspawnTroll = trollSpawnPoints [Random.Range(0, trollSpawnPoints.Count)];

        ork = Mathf.RoundToInt(amountOfEnemies / 10 * 6);
        dog = Mathf.RoundToInt(amountOfEnemies / 10 * 3);
        troll = Mathf.RoundToInt(amountOfEnemies / 10 * 1);


        for (int i = 0; i < ork; i++)
        {
            Instantiate(enemies[0], randomspawnOrk.transform);
        }
        for (int i = 0; i < dog; i++)
        {
            Instantiate(enemies[1], randomspawnDog.transform);
        }
        for (int i = 0; i < troll; i++)
        {
            Instantiate(enemies[2], randomspawnTroll.transform);
        }
    }
}
