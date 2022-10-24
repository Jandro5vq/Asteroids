using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Activar/Desactivar muerte")]
    public bool canDie = true;
    bool Dead = false;
    [Header(" --> Se multiplican x100 las velocidades <-- ")]
    public float rotationSpeed = 2f;
    public float movementSpeed = 6f;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        float rSpeed = rotationSpeed * 100;
        float mSpeed = movementSpeed * 100;

        if (!Dead)
        {
            // MOVIMIENTO
            float vertical = Input.GetAxis("Vertical");
            if (Input.GetAxis("Vertical") > 0)
            {
                rb.AddForce(vertical * mSpeed * transform.up * Time.deltaTime);
            }

            rb.rotation += -Input.GetAxis("Horizontal") * rSpeed * Time.deltaTime;

            if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
            {
                anim.SetBool("move", true);
            }
            else
            {
                anim.SetBool("move", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canDie)
        {
            if (collision.tag == "Asteroid" || collision.tag == "Ebullet" || collision.tag == "Enemy")
            {
                GameManager.instance.vidas -= 1;

                if (GameManager.instance.vidas >= 1)
                {
                    GameManager.instance.clip.Play();
                    transform.position = new Vector3(0, 0, 0);
                    rb.velocity = new Vector2(0, 0);
                }

                if (GameManager.instance.vidas == 0)
                {
                    StartCoroutine(Die());
                }
            }
        }
    }

    IEnumerator Die()
    {
        anim.SetTrigger("dead");
        AudioSource Aclip = this.GetComponent<AudioSource>();
        Aclip.Play();
        Dead = true;
        yield return  new WaitForSeconds(1);
        Time.timeScale = 0;
    }
}
