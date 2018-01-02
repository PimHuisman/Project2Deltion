using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject diePanel;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Health(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Time.timeScale = 0;
            diePanel.SetActive(true);
            Cursor.visible = true;
            print("you are Dead!!!!??");
        }
    }
    public void ResetLevel()
    {
        Time.timeScale = 1;
    }
}


