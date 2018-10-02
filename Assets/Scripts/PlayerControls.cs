﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float accelerationForce;
    [SerializeField]
    private float maxSpeed = 5;

    private float HorizontalInput;

    // Use this for initialization
    void Start() {
        Debug.Log("This is Start");
    }

    // Update is called once per frame
    void Update() {
        HorizontalInput = Input.GetAxis("Horizontal");


        //this is the syntax for printing to the console. 
        //Debug.Log("Test");

    }

    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * HorizontalInput * accelerationForce);
        Vector2 clampedVelocity = rb2d.velocity;
        clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, - maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;
    }
}
