using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float balloonGravity = -2.00f;
    private float _gravity = -9.81f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gravity = _gravity * balloonGravity * Vector3.up;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    private void OnMouseDown()
    {
        PoppedBalloonsCounter.score++;
        Destroy(gameObject);
    }
}
