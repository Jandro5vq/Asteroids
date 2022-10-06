using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AsteroidsLogic : MonoBehaviour
{
    public GameObject Small;
    public GameObject Medium;
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (type == "big")
            {
                Instantiate(Medium, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation * Quaternion.Euler(0, 0, -90));
                Instantiate(Medium, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation * Quaternion.Euler(0, 0, 90));
                Destroy(this.gameObject);
            }
            else if (type == "medium")
            {
                Instantiate(Small, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation * Quaternion.Euler(0, 0, -90));
                Instantiate(Small, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation * Quaternion.Euler(0, 0, 90));
                Destroy(this.gameObject);
            }
            else if (type == "small")
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void death(int x)
    {
        
        Destroy(this.gameObject);
    }
}
