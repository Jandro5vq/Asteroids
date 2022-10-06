using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Activa/Desactivar el Spawner")]
    public bool Enable = true;
    [Header("Retraso entre aparición")]
    public float retraso = 1f;
    [Header("")]
    public GameObject BigAsteroid;
    public GameObject MediumAsteroid;
    public GameObject SmallAsteroid;


    private float delay = 1f;

    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }

        if (Enable == true && delay <= 0)
        {
            delay = retraso;

            float prob = Random.value;

            if(prob >= 0.5)
            {
                Aspawn(BigAsteroid);
            }
            else if(prob >= 0.3)
            {
                Aspawn(MediumAsteroid);
            }
            else
            {
                Aspawn(SmallAsteroid);
            }
        }
    }

    void Aspawn(GameObject asteroid)
    {
        float r = Random.value;
        // AARRIBA
        if (r <= 0.2)
        {
            Vector3 vector = new Vector3(Random.Range(-15, 15), 12, 0);
            Instantiate(asteroid, vector, transform.rotation);
        }
        // ABAJO
        else if (r <= 0.4)
        {
            Vector3 vector = new Vector3(Random.Range(-15, 15), -12, 0);
            Instantiate(asteroid, vector, transform.rotation);
        }
        // DERECHA
        else if (r <= 0.6)
        {
            Vector3 vector = new Vector3(20, Random.Range(-7.5f, 7.5f), 0);
            Instantiate(asteroid, vector, transform.rotation);
        }
        // IZQUIERDA
        else
        {
            Vector3 vector = new Vector3(-20, Random.Range(-7.5f, 7.5f), 0);
            Instantiate(asteroid, vector, transform.rotation);
        }
    }
}
