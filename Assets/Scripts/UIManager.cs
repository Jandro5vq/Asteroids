using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{

    public GameObject NumPoints;
    public GameObject NumTime;
    public GameObject GameOver;
    public GameObject Pause;

    public GameObject[] LifeImg;

    private TextMeshProUGUI PointsText;
    private TextMeshProUGUI TimeText;

    float timer = 0.0f;

    void Start()
    {
        PointsText = NumPoints.GetComponent<TextMeshProUGUI>();
        TimeText = NumTime.GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        PointsText.text = GameManager.instance.puntos.ToString();

        timer += Time.deltaTime;
        
        int min = Mathf.FloorToInt(timer / 60.0f);
        int sec = Mathf.FloorToInt(timer - min * 60);
        TimeText.text = string.Format("{0:00}:{1:00}", min, sec);

        int vidas = GameManager.instance.vidas;

        if (vidas == 2)
        {
            LifeImg[2].SetActive(false);
        }
        if (vidas == 1)
        {
            LifeImg[1].SetActive(false);
        }
        if (vidas == 0)
        {
            LifeImg[0].SetActive(false);
            GameOver.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.vidas > 0)
        {
            if (Pause.activeSelf)
            {
                Pause.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Pause.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        SceneManager.LoadScene(0);
    }

    public void returnn()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
}
