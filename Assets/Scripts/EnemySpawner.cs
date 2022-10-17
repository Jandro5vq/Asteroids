using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemySpawner : MonoBehaviour
{
    public GameObject NaveEnemiga;
    GameObject Nave;
    float TempTime = 60f;
    void Start()
    {
        Nave = GameObject.Find("NavePlayer");
    }

    // Update is called once per frame
    void Update()
    {
        int pts = Nave.GetComponent<PointManager>().Points;

        if (Time.fixedTime >= TempTime)
        {
            if (pts >= 1000)
            {
                Vector3 vector = new Vector3(Random.Range(-15.5f, 15.5f), 12, 0);
                Instantiate(NaveEnemiga, vector, transform.rotation);
            }

            TempTime = Time.fixedTime + 60;
        }
    }
}
