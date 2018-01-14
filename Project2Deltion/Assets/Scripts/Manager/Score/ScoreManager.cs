using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreTab;
    [SerializeField] private int currentKilles;
    public int currentPoints;
    [SerializeField] private Text killesManager;
    [SerializeField] private Text pointsManager;

    void Start()
    {
        killesManager.text = ("Killes" + "/" + currentKilles);
        pointsManager.text = ("Points" + "/" + currentPoints);
    }


    void Update ()
    {
        if (Input.GetButtonDown("Tab"))
        {
            scoreTab.SetActive(true);
        }
        if (Input.GetButtonUp("Tab"))
        {
            scoreTab.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Points(100, 0);
        }
    }

    public void Killes(int kill)
    {
        currentKilles += kill;
        killesManager.text = ("Killes" + "/" + currentKilles);
    }
    public void Points(int point, int dPoint)
    {
        if (currentPoints <= 0)
        {
            currentPoints = 0;
        }
        if (currentPoints >= dPoint)
        {
            currentPoints -= dPoint;
        }
        currentPoints += point;
        pointsManager.text = ("Points" + "/" + currentPoints);
    }
}
