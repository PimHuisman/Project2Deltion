using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorShow : MonoBehaviour
{
	void Start ()
    {
        Cursor.visible = false;
    }
	
	void Update ()
    {
		if (Input.GetButtonUp("Cancel"))
        {
            Cursor.visible = !Cursor.visible;
        }
	}
}
