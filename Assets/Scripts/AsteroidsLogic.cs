using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidsLogic : MonoBehaviour
{
    [Header("Asteroid Prefab")]
    public GameObject Asteroid;
    [Header("Explosion Prefab")]
    public GameObject Exp;
    [Header("Opciones de Sprites")]
    public Sprite[] Sprites;
    [Header("Maximo y Minimo de la velocidad aleatoria")]
    public float MaxSpeed = 200;
    public float MinSpeed = 125;

    private Rigidbody2D rb;
    private float speed;
    private float angle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.instance.asteroides++;

        int rand;
        rand = Random.Range(0, Sprites.Length);
        GetComponent<SpriteRenderer>().sprite = Sprites[rand];

        speed = Random.Range(MaxSpeed, MinSpeed);

        rb.AddForce(transform.up * speed);

        angle = Random.Range(-0.3f, 0.3f);
    }

    private void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, angle * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            int rand = Random.Range(1, 3);

            for (int i = 0; i <= rand; i++)
            {
                if (this.gameObject.transform.localScale.x > 2)
                {
                    GameObject A = Instantiate(Asteroid, new Vector3(transform.position.x + 2, transform.position.y + 2, 0), transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    A.transform.localScale = new Vector3(A.transform.localScale.x * 0.75f, A.transform.localScale.y * 0.75f, A.transform.localScale.z);
                    A.GetComponent<AsteroidsLogic>().MaxSpeed = A.GetComponent<AsteroidsLogic>().MaxSpeed * 1.25f;
                    A.GetComponent<AsteroidsLogic>().MinSpeed = A.GetComponent<AsteroidsLogic>().MinSpeed * 1.25f;
                }
            }

            if (this.gameObject.transform.localScale.x == 3f)
            {
                GameManager.instance.puntos += 5;
            }
            else if (this.gameObject.transform.localScale.x >= 2f)
            {
                GameManager.instance.puntos += 10;
            }
            else if (this.gameObject.transform.localScale.x >= 1f)
            {
                GameManager.instance.puntos += 20;
            }
            Instantiate(Exp, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            GameManager.instance.asteroides--;
            Destroy(this.gameObject);
        }
    }
}
