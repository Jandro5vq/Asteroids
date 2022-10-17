using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telepor : MonoBehaviour
{
    public float LimiteX = 18.2f;
    public float LimiteY = 10.3f;

    void Update()
    {
        if( transform.position.x > LimiteX)
        {
            transform.position = new Vector3(-LimiteX, transform.position.y);
        }

        if (transform.position.x < -LimiteX)
        {
            transform.position = new Vector3(LimiteX, transform.position.y);
        }

        if (transform.position.y > LimiteY)
        {
            transform.position = new Vector3(transform.position.x, -LimiteY);
        }

        if (transform.position.y < -LimiteY)
        {
            transform.position = new Vector3(transform.position.x, LimiteY);
        }
    }
}
