using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    private Collider2D collider2D;
    private PlayerMovement playerMovement;
    private GameObject player;
    private Rigidbody2D rb;
    public float speed=2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.left * speed;
    }
}
