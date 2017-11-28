using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    //Mana
    [SerializeField] private float currentMana;
    [SerializeField] private float maxMana;
    [SerializeField] private float upMana;
    [SerializeField] private float damage;
    // Stamina
    [SerializeField] private float currentStamina;
    [SerializeField] private float maxStamina;
    [SerializeField] private float upStamina;
    [SerializeField] private float downStamina;

    private float timer;

    void Start()
    {
        currentMana = maxMana;
        currentStamina = maxStamina;
    }
    void Update()
    {
        Mana();
        Stamina();
        Abillity1();
        Abillity2();
        Abillity3();
    }
    void Mana()
    {
        // All below CurrentMana
        if (currentMana <= 0)
        {
            currentMana = 0;
        }
        if (currentMana < maxMana)
        {
            currentMana += upMana * Time.deltaTime;
        }
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
    }
    void Stamina()
    {
        if (currentStamina <= 0)
        {
            currentStamina = 0;
        }
        if (currentStamina < maxStamina)
        {
            currentStamina += upStamina * Time.deltaTime;
        }
        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }
    }
    void Abillity1()
    {
        // Ability 01 
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentMana < damage)
            {
                currentMana -= 0;
            }
            else
            {
                currentMana -= damage;
            }
        }
    }
    void Abillity2()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (currentStamina < downStamina)
            {
                currentStamina -= 0;
            }
            else
            {
                currentStamina -= downStamina;
            }
        }
    }
    void Abillity3()
    {

    }

}

