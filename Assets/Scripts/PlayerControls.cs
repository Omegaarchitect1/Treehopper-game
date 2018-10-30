using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private Collider2D playerGroundCollider;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    [SerializeField]
    private float accelerationForce;

    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private float JumpForce = 2;

    [SerializeField]
    private Collider2D GroundDetectTrigger;

    [SerializeField]
    private PhysicsMaterial2D playerMovingPhysicsMaterial, playerStoppingPhysicsMaterial;


    private float HorizontalInput;
    private Collider2D[] GroundHitDetectionResults = new Collider2D[16];
    private bool isOnGround;
    private Checkpoint currentCheckpoint;

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

    private void UpdatePhysicsMaterial()
    {
        if (Mathf.Abs(HorizontalInput) > 0)
        {
            playerGroundCollider.sharedMaterial = playerMovingPhysicsMaterial;
        }
        else
        {
            playerGroundCollider.sharedMaterial = playerStoppingPhysicsMaterial;
        }
    }

    private void UpdateIsOnGround()
    {
        isOnGround = GroundDetectTrigger.OverlapCollider(groundContactFilter, GroundHitDetectionResults) > 0;
        //Debug.Log("Is on Ground: " + IsOnGround);
    }

    private void UpdateHorizontalInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb2d.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

        }
    }

    void FixedUpdate()
    {
        UpdatePhysicsMaterial();
        Move();
    }

    private void Move()
    {
    rb2d.AddForce(Vector2.right* HorizontalInput * accelerationForce);
    Vector2 clampedVelocity = rb2d.velocity;
    clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, - maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;
    }

    public void Respawn()
    {
        if (currentCheckpoint == null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
        {
            rb2d.velocity = Vector2.zero;
            transform.position = currentCheckpoint.transform.position;
        }
    }

    public void SetCurrentCheckpoint(Checkpoint newcurrentCheckpoint)
    {
        if (currentCheckpoint != null)
            currentCheckpoint.setIsActivated(false);

        currentCheckpoint = newcurrentCheckpoint;
        currentCheckpoint.setIsActivated(true);
    }
}
