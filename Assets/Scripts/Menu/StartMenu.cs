using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject menu;
    float tempo;

    // Update is called once per frame
    void Update()
    {

        tempo += Time.deltaTime;

        if (tempo >= 1.35f)
        {
            menu.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {

    }
}
