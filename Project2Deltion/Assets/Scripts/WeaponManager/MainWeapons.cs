using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWeapons : MonoBehaviour
{
    //Ammo Text
    [SerializeField] private Text ammoText;
    [SerializeField] private string weaponType;
    //Ammo
    public int currentAmmo;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int fireAmmo;
    //Clip (Magazine)
    [SerializeField] private int maxClip;
    [SerializeField] private int currentClipAmount;
    //RayCastBullets
    [SerializeField] GameObject hole;
    [SerializeField] private float raycastLength;
    [SerializeField] private Transform cameraPotition;
    private RaycastHit hit;
    private bool bulletHole;
    //ReloadTimer
    private bool timeSwitch;
    private float currentTime;
    [SerializeField] private float maxTime;
    //AddForce
    [SerializeField] private float inpactForce;
    //FireRate
    private bool fire;
    private float fireTime;
    [SerializeField] private float fireAgain;

    void Start()
    {
        currentClipAmount = maxClip;
        currentAmmo = maxAmmo;
        currentTime = maxTime;
        bulletHole = true;
        timeSwitch = false;
        fire = false;
        fireTime = fireAgain;
    }
    void Update()
    {
        AmmoCheck();
        Weapon();
        Reload();
        FireRate();
    }
    void Reload()
    {
        // Press R for reload or when it hits zero
        if (currentClipAmount <= maxAmmo)
        {
            if (Input.GetButtonDown("R") || currentClipAmount <= 0)
            {
                timeSwitch = true;
            }
        }
    }
    void AmmoCheck()
    {
        // Ammo Text
        ammoText.text = (weaponType + currentClipAmount + "/" + currentAmmo);
        // Check if timeSwitch == true
        if (timeSwitch)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime <= 0)
        {
            // If you have NO Ammo at all
            if (currentAmmo <= 0 && currentClipAmount <= 0)
            {
                bulletHole = false;
            }
            // If you have Ammo for clip
            else
            {
                timeSwitch = false;
                currentTime = maxTime;
                int needAmmo = maxClip - currentClipAmount;
                currentClipAmount += needAmmo;
                currentAmmo -= needAmmo;
                bulletHole = true;
                if (currentAmmo < maxClip)
                {
                    currentClipAmount += currentAmmo;
                }
                if (currentClipAmount >= maxClip)
                {
                    currentClipAmount = maxClip;
                }
                if (currentClipAmount <= 0)
                {
                    currentClipAmount = 0;
                    bulletHole = false;
                }
                if (currentClipAmount >= maxClip)
                {
                    currentClipAmount = maxClip;
                }
                if (currentAmmo <= 0)
                {
                    currentAmmo = 0;
                }
                if (currentAmmo >= maxAmmo)
                {
                    currentAmmo = maxAmmo;
                }
            }
        }
    }

    void FireRate()
    {
        if (fire)
        {
            fireTime -= Time.deltaTime;
        }
        if (fireTime <= 0)
        {
            fire = false;
            fireTime = fireAgain;
        }
    }

    void Weapon()
    {
        // Weapon Functions
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletHole)
            {
                if (!fire)
                {
                    if (currentClipAmount > 0)
                    {
                        if (timeSwitch)
                        {
                            timeSwitch = false;
                            currentTime = maxTime;
                        }
                        currentClipAmount -= fireAmmo;
                        if (Physics.Raycast(cameraPotition.position, cameraPotition.forward, out hit, raycastLength))
                        {
                            GameObject g = Instantiate(hole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                            g.transform.parent = hit.transform;

                            if (hit.rigidbody != null)
                            {
                                hit.rigidbody.AddForce(-hit.normal * inpactForce);
                            }
                        }
                    }
                }
            }
            fire = true;
            Debug.DrawRay(cameraPotition.position, cameraPotition.forward * 10, Color.red);
        }
    }
    
}

