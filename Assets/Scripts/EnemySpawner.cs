using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab Nave Enemiga")]
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
        int pts = GameManager.instance.puntos;

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
