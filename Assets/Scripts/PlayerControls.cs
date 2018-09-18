using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
        Debug.Log("This is Start");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector2(5,myRigidbody.velocity.y);
            //Move right
        }
        //this is the syntax for printing to the console. 
        //Debug.Log("Test");

	}
}
