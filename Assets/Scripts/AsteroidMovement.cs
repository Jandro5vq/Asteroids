using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("Opciones de Sprites")]
    public Sprite[] Sprites; 
    [Header("Tiempo hasta desaparecer")]
    public float Duration = 10f;
    [Header("Maximo y Minimo de la velocidad aleatoria")]
    public float MaxSpeed = 200;
    public float MinSpeed = 125;
    private float speed;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int rand;
        rand = Random.Range(0, Sprites.Length);
        GetComponent<SpriteRenderer>().sprite = Sprites[rand];


        speed = Random.Range(MaxSpeed,MinSpeed);

        rb.AddForce(transform.up * speed);
      
        angle = Random.Range(-0.3f, 0.3f);
    }

    private void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, angle);
        Destroy(this.gameObject, Duration);
    }
}
