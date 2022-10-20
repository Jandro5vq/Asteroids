using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralBoost : MonoBehaviour
{
    [Header("Elige una opcion:")]
    public bool PortalGun = false;
    public bool MeeseeksBox = false;
    public bool Plumbus = false;

    [Header("Fuerza de movimiento")]
    public float force = 100f;

    float Angle;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Angle = Random.Range(100, 135) * RandomSign();

        Quaternion Rotation = Quaternion.Euler(0, 0, Angle);

        rb.AddForce(Rotation * transform.up * force);

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
        if (collision.CompareTag("Player") && PortalGun)
        {
            Debug.Log("SHIELD ON");
            collision.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player") && MeeseeksBox)
        {
            Debug.Log("MULTISHOT ON");
            collision.transform.GetChild(2).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player") && Plumbus)
        {
            Debug.Log("??? ON");
            Destroy(this.gameObject);
        }
    }
}
