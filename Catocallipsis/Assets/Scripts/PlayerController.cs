using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These are two different movement systems.

// public class PlayerController : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     public float acceleration = 10f;
//     public float deceleration = 15f;

//     private Rigidbody2D rb;
//     private Vector2 currentVelocity;

//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     private void Update()
//     {
//         float horizontalInput = Input.GetAxis("Horizontal");
//         float verticalInput = Input.GetAxis("Vertical");

//         Vector2 targetVelocity = new Vector2(horizontalInput, verticalInput) * moveSpeed;
//         currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
//         rb.velocity = currentVelocity;

//         if (targetVelocity == Vector2.zero)
//         {
//             currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, deceleration * Time.deltaTime);
//             rb.velocity = currentVelocity;
//         }
//     }
// }

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        rb.velocity = movement * moveSpeed;
    }

    private void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}