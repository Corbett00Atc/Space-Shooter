using UnityEngine;
using System.Collections;

public class RandomHorizontalMover : MonoBehaviour
{
    private float angleSpeed;
    private float forwardSpeed;
    private float locationX;

    //private int selected = values[Random.Range( 0, values.Length )];
    private int[] xAxisForce = { 0, 0, 0, 0, 0,   1, 1, 1, 1, 1,   2, 2, 2,   3, 3, 3,    4, 4, 4,   5, 5,};



    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();

        // grabs X position
        locationX = rigidBody.transform.position.x;
        angleSpeed = Generate(locationX);
 
        forwardSpeed = Random.Range(-15, -5);

        rigidBody.velocity = transform.TransformDirection(angleSpeed, 0, forwardSpeed);
    } 

    private float Generate(float locationX)
    {
        if (locationX > 5)
        {
            return angleSpeed = xAxisForce[Random.Range(0, xAxisForce.Length - 1)] * -1;
        }
        else if (locationX < -5)
        {
            return angleSpeed = xAxisForce[Random.Range(0, xAxisForce.Length - 1)];
        }
        else
        {
            return angleSpeed = Random.Range(-2, 2);
        }
    }

}

