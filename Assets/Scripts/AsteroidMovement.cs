using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Maximo y Minimo de la velocidad aleatoria")]
    public float MaxSpeed = 200;
    public float MinSpeed = 125;
    private float speed;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = Random.Range(MaxSpeed,MinSpeed);

        if (transform.position[1] >= 11.5)
        {
            rb.AddForce(-transform.up * speed);
        }
        else if(transform.position[1] <= -11.5)
        {
            rb.AddForce(transform.up * speed);
        }
        else if (transform.position[0] >= 5)
        {
            rb.AddForce(-transform.right * speed);
        }
        else if (transform.position[0] <= -5)
        {
            rb.AddForce(transform.right * speed);
        }
        else
        {
            rb.AddForce(-transform.up * speed);
        }

        angle = Random.Range(-0.3f, 0.3f);
    }

    private void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, angle);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
