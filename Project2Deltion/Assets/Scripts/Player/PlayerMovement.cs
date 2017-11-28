using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumVelocity;
    [SerializeField] private float speedM;
    private Vector3 movmentVector;
    private Vector3 cameraMovement;
    private Vector3 velocity;
    private Rigidbody feet;
    private int jump = 1;
    private int maxJump;
    private float currentSpeed;



    void Start ()
    {
        velocity = new Vector3(0,jumVelocity,0);
        maxJump = 1;
        currentSpeed = walkSpeed;
        feet = GetComponent<Rigidbody>();
	}

	void Update ()
    {
        movmentVector.x = Input.GetAxis("Horizontal");
        movmentVector.z = Input.GetAxis("Vertical");
        transform.Translate(movmentVector * currentSpeed * Time.deltaTime);

        cameraMovement.y = Input.GetAxis("Mouse X");
        transform.Rotate(cameraMovement *speedM);

        if (Input.GetButtonDown("LeftShift"))
        {
            currentSpeed = runSpeed;
        }
        else if (Input.GetButtonUp("LeftShift"))
        {
            currentSpeed = walkSpeed;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (jump < maxJump)
            {
                feet.velocity = velocity;
                jump += 1;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        jump = 0;
    }
}
