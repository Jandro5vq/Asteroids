using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 5;
    void Start()
    {
        Destroy(this.gameObject, time);
    }

}
