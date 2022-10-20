using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject menu;
    float tempo;

    private void Start()
    {
        Time.timeScale = 1;
    }
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
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(y);
    }

    public void Options()
    {

    }
}
