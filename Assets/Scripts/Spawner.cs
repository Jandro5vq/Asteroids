using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Activa/Desactivar el Spawner")]
    public bool Enable = true;
    [Header("Limites  de aparición")]
    public float Xmax = 16.7f;
    public float Ymax = 8.5f;
    [Header("Retraso entre aparición")]
    [Range(0.1f, 1)]
    public float retraso = 1f;
    [Header("")]
    public int ast_min = 2;
    public int ast_max = 8;
    public GameObject Asteroid;
    int lvlpts = 1000;

    void Update()
    {
        if(Enable && ast_min > GameManager.instance.asteroides && GameManager.instance.asteroides < ast_max)
        {
            Vector3 vector = new Vector3(Random.Range(-Xmax, Xmax), Random.Range(-Ymax, Ymax), 0);

            while (Vector3.Distance(vector, new Vector3(0,0)) < 2)
            {
                vector = new Vector3(Random.Range(-Xmax, Xmax), Random.Range(-Ymax, Ymax), 0);
            }
            Instantiate(Asteroid, vector, transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }

        if (GameManager.instance.puntos >= lvlpts)
        {
            ast_min += 1;
            ast_max += 1;

            lvlpts += 500; 
        }
    }
}
