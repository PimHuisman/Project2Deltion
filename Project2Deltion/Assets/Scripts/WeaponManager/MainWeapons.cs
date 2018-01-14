using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWeapons : MonoBehaviour
{
    //ToolbarWeapon
    [HideInInspector]
    public int weaponToolbarTop;
    public int weaponToolbarBottom;
    public string weaponCurrentTab;
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
    [SerializeField] private GameObject bloodHole;
    [SerializeField] private GameObject houseHole;
    [SerializeField] private GameObject normalHole;
    [SerializeField] private GameObject muzzelFlash;
    [SerializeField] private float raycastLength;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private Transform barrelEnd;
    private RaycastHit hit;
    public bool mayFire;
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
    //Damage
    [SerializeField] private float damage;
    //OutofAmmo
    [SerializeField] private GameObject outofAmmo;
    [SerializeField] private GameObject needtoReload;

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
        Weapon();
        Reload();
        FireRate();
    }
    void Reload()
    {
        // Press R for reload or when it hits zero
        if (currentClipAmount < maxClip)
        {
            if (mayFire)
            {
                if (Input.GetButtonDown("R") || currentClipAmount <= 0)
                {
                    timeSwitch = true;
                }
            }
        }
    }
    public void AddAmmo(int ammo)
    {
        currentAmmo += ammo;
    }
    void AmmoCheck()
    {
        // Ammo Text
        ammoText.text = (weaponType + currentClipAmount + "/" + currentAmmo);

        // If you have NO Ammo at all
        if (currentAmmo <= 0 && currentClipAmount <= 0)
        {
            mayFire = false;
            outofAmmo.SetActive(true);
            needtoReload.SetActive(false);
        }
        else
        {
            outofAmmo.SetActive(false);
        }
        // Check if timeSwitch == true
        if (timeSwitch)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentClipAmount < maxClip && currentAmmo <= 0)
        {
            timeSwitch = false;
        }
        // Calculate a Percentage of the hole Clip 
        int amount = maxClip / 5;
        if (currentClipAmount <= amount && mayFire)
        {
            needtoReload.SetActive(true);
        }
        else
        {
            needtoReload.SetActive(false);
        }
        if (currentTime <= 0)
        {
            mayFire = true;
            timeSwitch = false;
            currentTime = reloadTime;
            if (currentClipAmount >= 0 && currentAmmo < maxClip)
            {
                int ammoOver = currentAmmo;
                currentClipAmount += currentAmmo;
                currentAmmo -= ammoOver;
            }
            else
            {
                int needAmmo = maxClip - currentClipAmount;
                currentClipAmount += needAmmo;
                currentAmmo -= needAmmo;
            }
            if (currentClipAmount > maxClip)
            {
                currentClipAmount = maxClip;
            }
            if (currentClipAmount == 0)
            {
                currentClipAmount = 0;
                mayFire = false;
            }
            if (currentAmmo == 0)
            {
                currentAmmo = 0;
            }
            if (currentAmmo > maxAmmo)
            {
                currentAmmo = maxAmmo;
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
        if (Input.GetButton("Fire1"))
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
                        //Destroy(Instantiate(muzzelFlash, barrelEnd.position, barrelEnd.rotation),0.1f);
                        currentClipAmount -= fireAmmo;
                        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, raycastLength))
                        {
                            if (hit.transform.tag != null)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    GameObject g = Instantiate(bloodHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                                    g.transform.parent = hit.transform;
                                    hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthCheck(damage);
                                }
                                if (hit.transform.tag == "House")
                                {
                                    GameObject h = Instantiate(houseHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                                    h.transform.parent = hit.transform;
                                }
                            }
                            if (hit.transform.tag == "Untagged")
                            {
                                GameObject n = Instantiate(normalHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                                n.transform.parent = hit.transform;
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
            Debug.DrawRay(cameraPosition.position, cameraPosition.forward * 10, Color.red);
        }
    }
}

