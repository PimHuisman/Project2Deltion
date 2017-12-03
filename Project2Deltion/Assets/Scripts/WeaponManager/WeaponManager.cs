using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    //Test
    [SerializeField] private GameObject mainWeapon;
    [SerializeField] private GameObject secondaryWeapon;
    [SerializeField] private GameObject weaponAbility;
    //All Ammo Text
    public Text ammoText;

    void Start ()
    {
		
	}

	void Update ()
    {
        //Test
        if (Input.GetButtonDown("Fire3"))
        {
            mainWeapon.gameObject.SetActive(false);
            secondaryWeapon.gameObject.SetActive(false);
            weaponAbility.gameObject.SetActive(true);
        }
    }
}
