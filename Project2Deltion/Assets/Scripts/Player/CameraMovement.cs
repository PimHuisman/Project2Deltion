using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 v02;
    public float speed;
    void Update()
    {
        v02.x = -Input.GetAxis("Mouse Y");
        transform.Rotate(v02 * speed);
    }
}
