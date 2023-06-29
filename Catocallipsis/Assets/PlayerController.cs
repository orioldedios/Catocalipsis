using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

       private Rigidbody2D rb;
       public float moveSpeed = 5f;
       public GameObject ProjectilePrefab;
//       public Transform ProjectileSpawn;
       public float projectileForce = 10f;
       public float projectileSpawnDistance = 1f;

    // Start is called before the first frame update
    void Start() {
            rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private bool gunCooldown = false;
public float shootCooldownTime = 0.5f;
private float shootTimer = 0f;

void Update()
{
    // Check if the gun is not on cooldown and the left mouse button is held down
    if (!gunCooldown && Input.GetMouseButton(0))
    {
        Shoot();
    }

    // Update the shoot timer and check if it has reached the cooldown time
    if (gunCooldown)
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootCooldownTime)
        {
            gunCooldown = false;
            shootTimer = 0f;
        }
    }

    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    Vector2 movement = new Vector2(horizontalInput, verticalInput);
    rb.velocity = movement * moveSpeed;
}

void Shoot()
{
    if (!gunCooldown)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = mousePosition - (Vector2)transform.position;
        shootDirection.Normalize();

        GameObject projectileObj = Instantiate(ProjectilePrefab, (Vector2)transform.position + (shootDirection * projectileSpawnDistance), Quaternion.identity);
        Rigidbody2D projectileRb = projectileObj.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(shootDirection * projectileForce, ForceMode2D.Impulse);

        gunCooldown = true; // Set the gun on cooldown
    }
}

}