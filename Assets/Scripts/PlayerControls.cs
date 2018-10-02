using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private ContactFilter2D groundContact;
    [SerializeField]
    private float accelerationForce;
    [SerializeField]
    private float maxSpeed = 5;
    [SerializeField]
    private float JumpForce = 2;
    [SerializeField]
    private Collider2D GroundDetectTrigger;

    private float HorizontalInput;
    private Collider2D[] GroundHitDetectionResults = new Collider2D[16];
    private bool IsOnGround;

    // Use this for initialization
    void Start() {
        Debug.Log("This is Start");
    }

    // Update is called once per frame
    void Update() {
        UpdateIsOnGround();
        UpdateHorizontalInput();
        Jump();
        //this is the syntax for printing to the console. 
        //Debug.Log("Test");

    }

    private void UpdateIsOnGround()
    {
        IsOnGround = GroundDetectTrigger.OverlapCollider(groundContact, GroundHitDetectionResults) > 0;
        //Debug.Log("Is on Ground: " + IsOnGround);
    }

    private void UpdateHorizontalInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsOnGround)
        {
            rb2d.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
    rb2d.AddForce(Vector2.right* HorizontalInput * accelerationForce);
    Vector2 clampedVelocity = rb2d.velocity;
    clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, - maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;
    }
}
