using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float expirationTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletTimeout());
    }

    IEnumerator BulletTimeout()
    {
        yield return new WaitForSeconds(expirationTime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
