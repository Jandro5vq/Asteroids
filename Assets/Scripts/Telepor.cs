using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telepor : MonoBehaviour
{
    public float LimiteX;
    public float LimiteY;

    void Update()
    {
        if( transform.position.x > LimiteX)
        {
            Debug.Log("Limite X + Superado");
            transform.position = new Vector3(-LimiteX, transform.position.y);
        }

        if (transform.position.x < -LimiteX)
        {
            Debug.Log("Limite X - Superado");
            transform.position = new Vector3(LimiteX, transform.position.y);
        }

        if (transform.position.y > LimiteY)
        {
            Debug.Log("Limite Y Superado");
            transform.position = new Vector3(transform.position.x, -LimiteY);
        }

        if (transform.position.y < -LimiteY)
        {
            Debug.Log("Limite Y Superado");
            transform.position = new Vector3(transform.position.x, LimiteY);
        }
    }
}
