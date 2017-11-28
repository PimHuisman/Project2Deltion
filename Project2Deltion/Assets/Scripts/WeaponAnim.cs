using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnim : MonoBehaviour
{
    static Animator anim;
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Click", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Click", false);
        }
    }
}
