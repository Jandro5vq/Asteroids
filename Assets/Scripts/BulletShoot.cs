using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject Bullet;
    public AudioSource BulletSound;
    private float delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        BulletSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && delay <= 0)
        {
                delay = 0.15f;  // this is the interval between firing.
                BulletSound.Play();
                Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
    }
}
