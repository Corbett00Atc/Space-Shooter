using UnityEngine;
using System.Collections;

public class MissileMover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();

        rigidBody.velocity = transform.forward * speed * -1;
    }
}