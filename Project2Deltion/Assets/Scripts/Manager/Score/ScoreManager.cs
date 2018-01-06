using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreTab;
    [SerializeField] private int currentKilles;
    [SerializeField] private int currentPoints;
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
    }


    public void Killes(int kill)
    {
        currentKilles += kill;
        killesManager.text = ("Killes" + "/" + currentKilles);
    }
    public void Points(int point)
    {
        currentPoints += point;
        pointsManager.text = ("Points" + "/" + currentPoints);
    }
}
