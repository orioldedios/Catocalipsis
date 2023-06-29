using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

       private Rigidbody2D rb;
       public float moveSpeed = 5f;
       public GameObject ProjectilePrefab;
//       public Transform ProjectileSpawn;
       public float projectileForce = 10f;

    // Start is called before the first frame update
    void Start() {
            rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) Shoot();

         float horizontalInput = Input.GetAxis("Horizontal");
         float verticalInput = Input.GetAxis("Vertical");
         Vector2 movement = new Vector2(horizontalInput, verticalInput);
//             rb.MovePosition(rb.position + movement);
             rb.velocity = movement * moveSpeed;

    }

    void Shoot() {
            GameObject projectileObj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D projectileRb = projectileObj.GetComponent<Rigidbody2D>();
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = mousePosition - (Vector2)transform.position;
            shootDirection.Normalize();
            projectileRb.AddForce(shootDirection * projectileForce, ForceMode2D.Impulse);
    }
}