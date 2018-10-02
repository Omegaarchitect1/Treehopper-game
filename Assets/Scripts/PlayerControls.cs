using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed;

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
        rb2d.AddForce(Vector2.right * HorizontalInput * speed);

    }
}
