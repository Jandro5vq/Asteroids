using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotLogic : MonoBehaviour
{
    public float Duracion = 8f;

    public GameObject Bullet;

    public float delayTime = 1f;
    private float delay;

    float TempTime;

    private void OnEnable()
    {
        TempTime = 0;
        delay = delayTime;
    }

    void Update()
    {
        TempTime += Time.deltaTime;
        if (Duracion <= TempTime)
        {
            this.gameObject.SetActive(false);
        }

        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }

        if (delay <= 0)
        {

            for (int i = 0; i <= 3; i++)
            {
                GameObject CH = transform.GetChild(i).gameObject;

                delay = delayTime;  // this is the interval between firing.
                Instantiate(Bullet, new Vector3(CH.transform.position.x, CH.transform.position.y, 0), CH.transform.rotation * Quaternion.Euler(0, 0, 180));
            }
        }

    }
}
