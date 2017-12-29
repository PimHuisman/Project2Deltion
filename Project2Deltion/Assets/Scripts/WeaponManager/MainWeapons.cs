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
    [SerializeField] private float raycastLength;
    [SerializeField] private Transform cameraPosition;
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

    public void Weapon()
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
                        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, raycastLength))
                        {
                            if (hit.transform.tag != null)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    GameObject g = Instantiate(bloodHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                                    g.transform.parent = hit.transform;
                                    hit.collider.gameObject.GetComponent<EnemyAI>().EnemyHealth(damage);
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

