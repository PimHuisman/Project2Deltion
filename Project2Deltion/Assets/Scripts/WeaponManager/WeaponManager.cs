using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private float scrollWheel;

    void Start()
    {
        weapons[0].SetActive(true);
    }
    void Update()
    {
        scrollWheel = Input.GetAxis("Mouse ScrollWheel")*5;

        if (scrollWheel <0)
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
        }
        else if (scrollWheel >0)
        {
            weapons[1].SetActive(true);
            weapons[0].SetActive(false);
        }
        if (Input.GetButtonDown("1"))
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
        }
        if (Input.GetButtonDown("2"))
        {
            weapons[1].SetActive(true);
            weapons[0].SetActive(false);
        }
    }
   

}

