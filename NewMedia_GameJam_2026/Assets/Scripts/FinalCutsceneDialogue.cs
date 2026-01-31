using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalCutsceneDialogue : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovementScript;
    [SerializeField] GameStateController gameStateController;
    [SerializeField] GameOverScript gameOverScript;

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    // UPDATED: Now accepts a Boolean and a GameObject reference
    public void StartDialogue()
    {
        gameObject.SetActive(true);
        playerMovementScript.enabled = false;
        gameStateController.isEKeyPressable = false;

        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Keep player frozen for the Game Over screen
            playerMovementScript.enabled = false;

            // Hide the dialogue box
            gameObject.SetActive(false);

            gameOverScript.GameOver();
        }
    }
}