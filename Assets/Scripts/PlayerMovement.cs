using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    private void OnBecameInvisible()
    {
        //Debug.Log("FUERA DE CAMARA");
        Vector3 actualPos = transform.position;

        // Derecha
        if (actualPos[0] >= 18)
        {
            //Debug.Log("DERECHA");
            actualPos[0] = actualPos[0] * -1f;
        }
        // Izquierda
        else if (actualPos[0] <= -18)
        {
            //Debug.Log("iZQUIERDA");
            actualPos[0] = actualPos[0] * -1f;
        }
        // Arriba
        if (actualPos[1] >= 10)
        {
            //Debug.Log("ARRIBA");
            actualPos[1] = actualPos[1] * -1f;
        }
        // Abajo
        else if (actualPos[1] <= -10)
        {
            //Debug.Log("ABAJO");
            actualPos[1] = actualPos[1] * -1f;
        }

        transform.position = actualPos;
    }
}
