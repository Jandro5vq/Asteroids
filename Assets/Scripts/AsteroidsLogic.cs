using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidsLogic : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject Exp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            int rand = Random.Range(1, 3);

            for (int i = 0; i <= rand; i++)
            {
                if (this.gameObject.transform.localScale.x > 2)
                {
                    GameObject A = Instantiate(Asteroid, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation * Quaternion.Euler(0, 0, Random.Range(0,360)));
                    A.transform.localScale = new Vector3(A.transform.localScale.x * 0.75f, A.transform.localScale.y * 0.75f, A.transform.localScale.z);
                    A.GetComponent<AsteroidMovement>().MaxSpeed = A.GetComponent<AsteroidMovement>().MaxSpeed * 1.25f;
                    A.GetComponent<AsteroidMovement>().MaxSpeed = A.GetComponent<AsteroidMovement>().MinSpeed * 1.25f;
                }
            }
            Instantiate(Exp, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

            GameObject Nave = GameObject.Find("NavePlayer");

            if (this.gameObject.transform.localScale.x == 3f)
            {
                Nave.GetComponent<PointManager>().Points += 5;
            }
            else if (this.gameObject.transform.localScale.x >= 2f)
            {
                Nave.GetComponent<PointManager>().Points += 10;
            }
            else if (this.gameObject.transform.localScale.x >= 1f)
            {
                Nave.GetComponent<PointManager>().Points += 20;
            }

            Destroy(this.gameObject);
        }
    }
}
