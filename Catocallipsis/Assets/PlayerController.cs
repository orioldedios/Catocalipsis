using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

       private Rigidbody2D rb;
       public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start() {
            rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
     float horizontalInput = Input.GetAxis("Horizontal");
             float verticalInput = Input.GetAxis("Vertical");
             Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
             rb.MovePosition(rb.position + movement);
    }
}
