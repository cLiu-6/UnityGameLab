using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject PauseScreen;
    public GameObject PauseButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        PauseButton.SetActive(true);
    }

    public void Pause()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
        Paused = true;
        PauseButton.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
