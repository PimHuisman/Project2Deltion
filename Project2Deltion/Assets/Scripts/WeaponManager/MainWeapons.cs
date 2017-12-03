using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWeapons : MonoBehaviour
{
    public Text ammoText;
    //Ammo for Musket
    public int currentAmmoM;
    [SerializeField] private int maxAmmoM;
    [SerializeField] private int fireAmmoM;
    //Clip for Musket
    [SerializeField] private int maxClipM;
    [SerializeField] private int currentClipAmountM;
    //RayCastBullets
    [SerializeField] GameObject musketHole;
    private RaycastHit hit;
    private bool bulletHoleM;

    void Start()
    {
        currentClipAmountM = maxClipM;
        currentAmmoM = maxAmmoM;
        bulletHoleM = true;
    }
    void Update()
    {
        Reload();
        MusketAmmo();
        Musket();
    }
    void Reload()
    {
        if (Input.GetButtonDown("R"))
        {
            //Musket Reload
            if (fireAmmoM <= 0)
            {
                currentAmmoM = 0;
                bulletHoleM = false;
            }
            else
            {
                int needAmmo = maxClipM - currentClipAmountM;
                currentClipAmountM += needAmmo;
                currentAmmoM -= needAmmo;
                bulletHoleM = true;
            }
            if (currentAmmoM < maxClipM)
            {
                currentClipAmountM += currentAmmoM;
            }
            if (currentClipAmountM >= maxClipM)
            {
                currentClipAmountM = maxClipM;
            }
        }
    }
    void MusketAmmo()
    {
        //MusketAmmo
        {
            ammoText.text = ("Musket:" + currentClipAmountM + "/" + currentAmmoM);
            if (currentClipAmountM <= 0)
            {
                currentClipAmountM = 0;
                bulletHoleM = false;
            }
            if (currentClipAmountM >= maxClipM)
            {
                currentClipAmountM = maxClipM;
            }
            if (currentAmmoM <= 0)
            {
                currentAmmoM = 0;
            }
            if (currentAmmoM >= maxAmmoM)
            {
                currentAmmoM = maxAmmoM;
            }
        }
    }
    void Musket()
    {
        // MainWeapon 
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1500f))
            {
                if (bulletHoleM)
                {
                    GameObject g = Instantiate(musketHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                    currentClipAmountM -= fireAmmoM;
                }
            }
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        }
    }
}

