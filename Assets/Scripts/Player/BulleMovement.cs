using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleMovement : MonoBehaviour
{
    public float speed = 400;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.CompareTag("Bullet"))
        {
            if (collision.CompareTag("Asteroid") || collision.CompareTag("Enemy"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
