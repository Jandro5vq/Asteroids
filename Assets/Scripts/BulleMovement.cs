using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleMovement : MonoBehaviour
{
    public float speed = 400;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy (this.gameObject);
    }
}
