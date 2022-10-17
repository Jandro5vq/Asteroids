using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{

    public int Points;
    public GameObject NumPoints;
    public GameObject NumTime;

    private TextMeshProUGUI PointsText;
    private TextMeshProUGUI TimeText;

    float timer = 0.0f;

    void Start()
    {
        PointsText = NumPoints.GetComponent<TextMeshProUGUI>();
        TimeText = NumTime.GetComponent<TextMeshProUGUI>();
        Points = 0;
        
    }

    void Update()
    {
        PointsText.text = Points.ToString();

        timer += Time.deltaTime;
        
        int min = Mathf.FloorToInt(timer / 60.0f);
        int sec = Mathf.FloorToInt(timer - min * 60);
        TimeText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
