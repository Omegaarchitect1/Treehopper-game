using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
  private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Checkpoint reached!.");
            PlayerControls player = collision.GetComponent<PlayerControls>();
            player.SetCurrentCheckpoint(this);
        }
        else
        {
            Debug.Log("Wait, who are you?");
        }
    }
}
