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
    private int currentClipAmount;
    //RayCastBullets
    [SerializeField] GameObject hole;
    [SerializeField] private float raycastLength;
    [SerializeField] private Transform cameraPotition;
    private RaycastHit hit;
    private bool mayFire;
    //ReloadTimer
    private bool timeSwitch;
    private float currentTime;
    [SerializeField] private float reloadTime;
    //AddForce
    [SerializeField] private float inpactForce;
    //FireRate
    private bool fire;
    private float fireTime;
    [SerializeField] private float fireAgain;
    //
    [SerializeField] private int damage;

    void Start()
    {
        currentClipAmount = maxClip;
        currentAmmo = maxAmmo;
        currentTime = reloadTime;
        mayFire = true;
        timeSwitch = false;
        fire = false;
        fireTime = fireAgain;
    }
    void Update()
    {
        AmmoCheck();
        Weapon(damage);
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
                mayFire = false;
            }
            // If you have Ammo for clip
            else
            {
                timeSwitch = false;
                currentTime = reloadTime;
                int needAmmo = maxClip - currentClipAmount;
                currentClipAmount += needAmmo;
                currentAmmo -= needAmmo;
                mayFire = true;
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
                    mayFire = false;
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

    public void Weapon(int damage)
    {
        // Weapon Functions
        if (Input.GetButtonDown("Fire1"))
        {
            if (mayFire)
            {
                if (!fire)
                {
                    if (currentClipAmount > 0)
                    {
                        if (timeSwitch)
                        {
                            timeSwitch = false;
                            currentTime = reloadTime;
                        }
                        currentClipAmount -= fireAmmo;
                        if (Physics.Raycast(cameraPotition.position, cameraPotition.forward, out hit, raycastLength))
                        {
                            GameObject g = Instantiate(hole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                            g.transform.parent = hit.transform;
                            if (hit.transform.gameObject != null)
                            {
                                //for (int i = 0; i < length; i++)
                                {
                                    hit.transform.gameObject.GetComponent<EnemyAI>().EnemyHealth(damage);
                                }
                            }

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

