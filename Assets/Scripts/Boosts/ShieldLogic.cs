using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldLogic : MonoBehaviour
{
    public float rotacion = 0.3f;
    public float Duracion = 8f;
    float TempTime;

    private void OnEnable()
    {
        TempTime = 0;
    }

    void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, rotacion * Time.deltaTime);
        TempTime += Time.deltaTime;
        if (Duracion <= TempTime)
        {
            this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity *= -1;
        }
    }
}
