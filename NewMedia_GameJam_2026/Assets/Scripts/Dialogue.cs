using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Dialogue : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovementScript;
    [SerializeField] GameStateController gameStateController;

    public GameObject movementTooltipTrigger;

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        movementTooltipTrigger.SetActive(false);
        
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

    void StartDialogue()
    {
        playerMovementScript.enabled = false; // Disables the entire movement script
        gameStateController.isEKeyPressable = false;
        index = 0;

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
            gameObject.SetActive(false);
            playerMovementScript.enabled = true; // Re-enables the movement script
            gameStateController.isEKeyPressable = true;

            movementTooltipTrigger.SetActive(true);
        }
    }
}