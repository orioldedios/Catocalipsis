using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float damping = 0.5f;

    public int maxHealth = 100;
    private int currentHealth;

    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        currentHealth = maxHealth;
    }

    private void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.AddForce(direction * moveSpeed);

        // Apply damping to reduce drift
        rb.velocity *= (1f - damping * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add logic for enemy defeat, such as playing an animation, awarding points, or destroying the enemy GameObject.
        Destroy(gameObject);
    }
}