using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject diePanel;
    public Slider healthSlider;
    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = CalculateHealth();
    }
    public void UpHealth(float health)
    {
        currentHealth += health;
        healthSlider.value = CalculateHealth();
    }
    public void Health(float damage)
    {
        //Check for Health 
        currentHealth -= damage;
        healthSlider.value = CalculateHealth();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Time.timeScale = 0;
            diePanel.SetActive(true);
            Cursor.visible = true;
            print("you are Dead!!!!??");
        }
    }
    public float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }
    // when you have died
    public void ResetLevel()
    {
        Time.timeScale = 1;
    }
}


