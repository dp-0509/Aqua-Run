using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDamage : MonoBehaviour
{
    private CircleCollider2D collider2D;
    private PlayerMovement playerMovement;
    private GameObject player;
    public float damage;
    private float health;
    void Start()
    {
        player  = GameObject.FindGameObjectWithTag("Player");
        collider2D = GetComponent<CircleCollider2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
        health = playerMovement.playerHealth;
    }
    
}
