using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Activar/Desactivar muerte")]
    public bool canDie = true;
    [Header(" --> Se multiplican x100 las velocidades <-- ")]
    public float rotationSpeed = 2f;
    public float movementSpeed = 6f;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        float rSpeed = rotationSpeed * 100;
        float mSpeed = movementSpeed * 100;


        // MOVIMIENTO
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(vertical * mSpeed * transform.up * Time.deltaTime);
        }

        rb.rotation += -Input.GetAxis("Horizontal") * rSpeed * Time.deltaTime;

        if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid" && canDie)
        {
            Debug.Log("COLISION CON ASTEROIDE");
            Destroy(this.gameObject);
        }
    }
}
