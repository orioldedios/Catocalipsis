using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float damping = 0.5f;

    public float maxHealth = 100;
    private float currentHealth;
    public float damageAmount = 1f;

    public GameObject scoring = null;

    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        scoring = GameObject.FindGameObjectWithTag("Scoring");

        currentHealth = maxHealth;
    }

    private void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.AddForce(direction * moveSpeed);

        // Apply damping to reduce drift
        rb.velocity *= (1f - damping * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            scoring.GetComponent<Scoring>().score += 1;
            scoring.GetComponent<Scoring>().i += 1;
            Die();
        }
    }

    private void Die()
    {
        // Add logic for enemy defeat, such as playing an animation, awarding points, or destroying the enemy GameObject.
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();
                        if (player != null)
                        {
                            player.TakeDamage(damageAmount);
                        }
                        Destroy(gameObject);
        }
    }
}