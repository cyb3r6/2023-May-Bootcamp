using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isFallen;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody pinRigidbody;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        pinRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isFallen = Quaternion.Angle(startRotation, transform.localRotation) > 5;
    }

    public void Reset()
    {
        // stopping enertia
        pinRigidbody.velocity = Vector3.zero;
        pinRigidbody.angularVelocity = Vector3.zero;

        // returning back to starting position & rotation
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
