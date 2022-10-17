using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Activa/Desactivar el Spawner")]
    public bool Enable = true;
    [Header("Cantidad de asteroides")]
    public int cantidad = 10;
    [Header("Limites  de aparición")]
    public float Xmax = 16.7f;
    public float Ymax = 8.5f;
    [Header("Retraso entre aparición")]
    public float retraso = 1f;
    [Header("")]
    public GameObject Asteroid;

    void Update()
    {
        if(Enable)
        {
            for (int i = 0; i < cantidad; i++)
            {
                Vector3 vector = new Vector3(Random.Range(-Xmax, Xmax), Random.Range(-Ymax, Ymax), 0);
                Instantiate(Asteroid, vector, transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }

            Enable = false;
        }
    }
}
