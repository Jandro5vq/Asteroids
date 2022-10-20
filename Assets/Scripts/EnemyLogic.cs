using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float force = 100f;
    public GameObject EBullet;
    float Angle;
    float delay;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Angle = Random.Range(95, 105) * RandomSign();

        Quaternion Rotation = Quaternion.Euler(0, 0, Angle);

        rb.AddForce(Rotation * transform.up * force);

    }

    private void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }

        if (delay <= 0)
        {
            delay = 0.5f;  // this is the interval between firing.
            Quaternion Rotation = Quaternion.Euler(0, 0, Random.Range(0,360));
            Instantiate(EBullet, new Vector3(transform.position.x, transform.position.y, 0), Rotation);
        }

        Destroy(this.gameObject, 20f);
    }

    private int RandomSign()
    {
        if (Random.Range(0, 2) == 0)
        {
            return -1;
        }
        return 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameManager.instance.puntos += 50;
            Destroy(this.gameObject);
        }
    }
}
