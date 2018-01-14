using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    [SerializeField] private RaycastHit hit;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private float raycastLength;
    [SerializeField] private GameObject ePickUp;
    [SerializeField] private GameObject crossHair;
    [SerializeField] private GameObject[] gun;
    [SerializeField] private Text itemInfo;
    void Update()
    {
        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, raycastLength))
        {
            if (hit.transform.tag == "AmmoPickUp")
            {
                string typeOf = hit.transform.GetComponent<AmmoPickUp>().type;
                itemInfo.text = (hit.transform.name + typeOf);
                crossHair.SetActive(false);
                ePickUp.SetActive(true);
                if (Input.GetButtonDown("E"))
                {
                    if (typeOf == "Musket")
                    {
                        Destroy(hit.transform.gameObject);
                        int upAmmo = hit.transform.GetComponent<AmmoPickUp>().ammo;
                        gun[0].GetComponent<MainWeapons>().mayFire = true;
                        gun[0].GetComponent<MainWeapons>().AddAmmo(upAmmo);
                    }
                    if (typeOf == "Shotgun")
                    {
                        Destroy(hit.transform.gameObject);
                        int upAmmo = hit.transform.GetComponent<AmmoPickUp>().ammo;
                        gun[1].GetComponent<MainWeapons>().mayFire = true;
                        gun[1].GetComponent<MainWeapons>().AddAmmo(upAmmo);
                    }
                }
            }
            if (hit.transform.tag == "HealthPickUp")
            {
                itemInfo.text = (hit.transform.name);
                ePickUp.SetActive(true);
                crossHair.SetActive(false);
                if (Input.GetButtonDown("E"))
                {
                    Destroy(hit.transform.gameObject);
                    float upHealth = hit.transform.GetComponent<HealthPickUp>().health;
                    gameObject.GetComponent<HealthManager>().UpHealth(upHealth);
                }
            }
        }
        else
        {
            crossHair.SetActive(true);
            ePickUp.SetActive(false);
        }
        Debug.DrawRay(cameraPosition.position, cameraPosition.forward * 2, Color.blue);
    }
}
