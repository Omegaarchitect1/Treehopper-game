using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private float inactiveRotationSpeed = 100, activeRotationSpeed = 400;

    [SerializeField]
    private float inactiveScale = 1, activeScale = 1.5f;

    private bool isActivated;

    private void Update()
    {
        updateRotation();
    }

    private void updateRotation()
    {
        float rotationSpeed = inactiveRotationSpeed;

        if (isActivated)
            rotationSpeed = activeRotationSpeed;

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void UpdateScale()
    {
        float scale = inactiveScale;

        if (isActivated)
            scale = activeScale;

        transform.localScale = Vector3.one * scale;
    }

    public void setIsActivated(bool value)
    {
        isActivated = value;
        UpdateScale();
    }

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
