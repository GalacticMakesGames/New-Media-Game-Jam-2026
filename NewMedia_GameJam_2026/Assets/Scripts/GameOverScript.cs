using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUI;



    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);

        AudioSource NormalSound = GameObject.Find("NormalSound").GetComponent<AudioSource>();
        AudioSource GameOverSound = GameObject.Find("GameOverSound").GetComponent<AudioSource>();

        GameOverSound.Play();
        NormalSound.mute = true;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartExitMenu");
        Debug.Log("MainMenu");
    }

    public void ExitGame()
    {
            Application.Quit();
            Debug.Log("ExitGame");
    }
}
