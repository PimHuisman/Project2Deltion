using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAbility : MonoBehaviour
{
    public Text ammoText;
    public Rigidbody bullet;
    public Transform barrelEnd;
    //Ammo for Harpoon
    public int currentAmmoH;
    [SerializeField] private int maxAmmoH;
    [SerializeField] private int fireAmmoH;
    //Clip for Harpoon
    [SerializeField] private int maxClipH;
    [SerializeField] private int currentClipAmountH;
    //RayCastBullets
    [SerializeField] GameObject harpoonHole;
    private RaycastHit hit;
    private bool bulletHoleH;

    void Start()
    {
        currentClipAmountH = maxClipH;
        currentAmmoH = maxAmmoH;
        bulletHoleH = true;
    }
    void Update ()
    {
        Debug.DrawRay(transform.position, transform.forward * -10, Color.red);
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletHoleH)
            {
                Rigidbody bulletInstance;
                bulletInstance = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                bulletInstance.AddForce(barrelEnd.forward * 1000);
                currentClipAmountH -= fireAmmoH;
            }
        }
        Reload();
        HarpoonAmmo();
    }
    void Reload()
    {
        if (Input.GetButtonDown("R"))
        {
            //Harpoon Reload
            if (fireAmmoH <= 0)
            {
                currentAmmoH = 0;
                bulletHoleH = false;
            }
            else
            {
                int needAmmo = maxClipH - currentClipAmountH;
                currentClipAmountH += needAmmo;
                currentAmmoH -= needAmmo;
                bulletHoleH = true;
            }
            if (currentAmmoH < maxClipH)
            {
                currentClipAmountH += currentAmmoH;
            }
            if (currentClipAmountH >= maxClipH)
            {
                currentClipAmountH = maxClipH;
            }
        }
    }
    void HarpoonAmmo()
    {
        //MusketAmmo
        {
            ammoText.text = ("Harpoon:" + currentClipAmountH + "/" + currentAmmoH);
            if (currentClipAmountH <= 0)
            {
                currentClipAmountH = 0;
                bulletHoleH = false;
            }
            if (currentClipAmountH >= maxClipH)
            {
                currentClipAmountH = maxClipH;
            }
            if (currentAmmoH <= 0)
            {
                currentAmmoH = 0;
            }
            if (currentAmmoH >= maxAmmoH)
            {
                currentAmmoH = maxAmmoH;
            }
        }
    }
}
