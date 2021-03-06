﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private float inactiveRotationSpeed = 100, activeRotationSpeed = 400;

    [SerializeField]
    private float inactiveScale = 1, activeScale = 1.5f;

    [SerializeField]
    private Color inactiveColor, activeColor;

    private bool isActivated;

    private SpriteRenderer spriteRenderer;

    private AudioSource audiosource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audiosource = GetComponent<AudioSource>();
        UpdateColor();
    }

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

    private void UpdateColor()
    {
        Color color = inactiveColor;

        if (isActivated)
            color = activeColor;

        spriteRenderer.color = color; 
    }


    public void setIsActivated(bool value)
    {
        isActivated = value;
        UpdateScale();
        UpdateColor();
    }

  private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActivated)
        {
            Debug.Log("Checkpoint reached!.");
            PlayerControls player = collision.GetComponent<PlayerControls>();
            player.SetCurrentCheckpoint(this);
            audiosource.Play();
        }
    }
}
