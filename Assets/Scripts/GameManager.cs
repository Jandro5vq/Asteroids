using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int puntos;
    public int vidas = 3;
    public int asteroides;
    public AudioSource clip;
    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;
        clip = this.GetComponent<AudioSource>();
    }
}
