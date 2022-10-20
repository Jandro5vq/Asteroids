using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    [Header("Boosts Prefabs")]
    public GameObject[] Items;

    [Header("Spawn Probability")]
    [Range(1, 100)]
    public int Probability = 1;

    [Header("Boost spawn delay")]
    public int DMin = 10;
    public int DMax = 20;

    float TempTime = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime >= TempTime)
        {
            int rand0 = Random.Range(0, 100);
            Debug.Log("RANDOM NUMBER ---> " + rand0);

            if (rand0 <= Probability)
            {
                int rand1 = Random.Range(0, Items.Length);;

                Vector3 vector = new Vector3(Random.Range(-17f, 17f), 11, 0);
                Instantiate(Items[rand1], vector, transform.rotation);

            }

            TempTime = Time.fixedTime + Random.Range(DMin, DMax);
        }
    }
}
