using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float amountOfEnemies;
    [SerializeField] private float upEnemies;

    [SerializeField] private float ork;
    [SerializeField] private float dog;
    [SerializeField] private float troll;
    public List<GameObject> enemyList = new List<GameObject>();
    public List<Transform> orkSpawnPoints = new List<Transform>();
    public List<Transform> dogSpawnPoints = new List<Transform>();
    public List<Transform> trollSpawnPoints = new List<Transform>();
    // Waves
    [SerializeField] private Text wave;
    [SerializeField] private int waveAmount;
    // Amount Of Enemies
    [SerializeField] Text totalEnemies;


    void Start ()
    {
        Create();
        waveAmount++;
    }

    void Update()
    {
        // Test
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Test
        }
        totalEnemies.text = ("Left" + "/" + enemyList.Count);
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
            amountOfEnemies = Mathf.RoundToInt(amountOfEnemies + upEnemies);
        }
        Transform randomspawnOrk = orkSpawnPoints [Random.Range(0, orkSpawnPoints.Count)];
        Transform randomspawnDog = dogSpawnPoints [Random.Range(0, dogSpawnPoints.Count)];
        Transform randomspawnTroll = trollSpawnPoints [Random.Range(0, trollSpawnPoints.Count)];
        if (enemyList.Count < amountOfEnemies)
        {
            ork = Mathf.RoundToInt(amountOfEnemies / 10 * 6);
            dog = Mathf.RoundToInt(amountOfEnemies / 10 * 3);
            troll = Mathf.RoundToInt(amountOfEnemies / 10 * 1);

            for (int i = 0; i < ork; i++)
            {
                enemyList.Add(Instantiate(enemies[0], randomspawnOrk.transform));
            }
            for (int i = 0; i < dog; i++)
            {
                enemyList.Add(Instantiate(enemies[1], randomspawnDog.transform));
            }
            for (int i = 0; i < troll; i++)
            {
                enemyList.Add(Instantiate(enemies[2], randomspawnTroll.transform));
            }
        }
    }
}
