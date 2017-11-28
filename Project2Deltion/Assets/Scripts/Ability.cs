using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    //Ammo
    public int currentAmmo;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int ammoAmount;
    //ClipMagazine
    [SerializeField] private int maxClip;
    [SerializeField] private int currentClipAmount;

    void Start()
    {
        currentClipAmount = maxClip;
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        Ammo();
        Weapon1();
        if (Input.GetButtonDown("R"))
        {
            if (currentClipAmount >= maxClip)
            {
                currentClipAmount = maxClip;
            }
            else
            {
                int needAmmo = maxClip - currentClipAmount;
                currentClipAmount += needAmmo;
                currentAmmo -= needAmmo;
            }
        }
    }
    void Ammo()
    {
        if (currentClipAmount <= 0)
        {
            currentClipAmount = 0;
        }
        if (currentClipAmount >= maxClip)
        {
            currentClipAmount = maxClip;
        }
        if (currentAmmo <= 0)
        {
            currentAmmo = 0;
        }
        if ( currentAmmo >= maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
    void Weapon1()
    {
        // Ability 01 
        if (Input.GetButtonDown("Fire1"))
        {
            currentClipAmount -= ammoAmount;
        }
    }
}

