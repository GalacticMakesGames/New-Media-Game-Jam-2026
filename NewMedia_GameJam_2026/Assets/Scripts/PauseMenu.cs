using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isGamePaused = false;

    [SerializeField] PlayerMovement playerMovementScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resumes game time
        playerMovementScript.enabled = true;
        isGamePaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pauses all time-based operations
        playerMovementScript.enabled = false;
        isGamePaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartFromCheckpoint()
    {
        // Calls the respawn function in the RespawnController
        FindObjectOfType<RespawnController>().RespawnPlayer();
        Resume(); // Unpause the game after respawning
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure time is normal when leaving the scene
        SceneManager.LoadScene("StartExitMenu");
    }
}
