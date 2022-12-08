using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    [Range(0f,3f)]
    public float vertSpeed = 0f;

    public GameObject mine;
    private MineDamage mineDamage;
    private float damage;
    public float playerHealth = 1;
    public float increment= 0.5f;
    public float score = 0;
    
    private float ySpeed;
    private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
    public Vector2 speed;
    public float yIncrement;
    private float yUp = 0;
    private static readonly int Speed = Animator.StringToHash("Speed");

    void Start()
    {
        InvokeRepeating(nameof(IncreaseSpeed),10f,10f);
        mineDamage = mine.GetComponent<MineDamage>();
        damage = mineDamage.damage;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        speed = new Vector2(moveSpeed, ySpeed)+new Vector2(increment,0);
        rb.velocity = speed;
        
        animator.SetFloat(Speed,speed.x);
        if (Input.GetKey(KeyCode.W))
        {
            ySpeed = vertSpeed+yUp;
        }
        else if (Input.GetKey(KeyCode.S))
            ySpeed = -vertSpeed-yUp;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mine"))
        {
            playerHealth -= damage;
            animator.SetTrigger(TakeDamage);
            other.gameObject.SetActive(false);
            //other.GetComponent<Animator>().SetBool("Explode",true);
            score -= 200;
        }
        else if (other.CompareTag($"Fish"))
        {
            other.gameObject.SetActive(false);
            score += 100;
        }
        else if (other.CompareTag($"BigFish"))
        {
            playerHealth -= damage;
            animator.SetTrigger(TakeDamage);
            other.gameObject.SetActive(false);
            score -= 200;
        }
        else if (other.CompareTag($"Snow"))
        {
            playerHealth -= damage;
            animator.SetTrigger(TakeDamage);
            score -= 200;
        }
    }

    private void IncreaseSpeed()
    {
        increment += 1.5f;
        score += 1000;
        yUp += yIncrement;
    }
    
}
