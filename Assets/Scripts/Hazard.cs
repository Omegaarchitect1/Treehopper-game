using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour {
private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
             Debug.Log("YOU ARE DEAD. NOT BIG SUPRISE.");
            PlayerControls player = collision.GetComponent<PlayerControls>();
            player.Respawn();
        }
        else
        {
            Debug.Log("Something else hit the Hazard");
        }
    }
}
