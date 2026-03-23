using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu: MonoBehaviour
{
	public GameObject mainMenuScreen;
	public GameObject controlsScreen;
	public GameObject creditsScreen;

    private void Start()
    {
		mainMenuScreen.SetActive(true);
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void OnStartClick()
	{
		SceneManager.LoadScene("TutorialLevel");
	}

	public void OnControlsButtonClick()
	{
        mainMenuScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void OnCreditsButtonClick()
    {
        mainMenuScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        mainMenuScreen.SetActive(true);
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void OnExitClick()
	{
		Application.Quit();
	}
}
