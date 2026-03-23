using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public FinalCutsceneDialogue dialogueScript;
    [SerializeField] bool hasTriggered = false;
    [SerializeField] PlayerMovement playerMovementScript;

    void Start()
    {
        playerMovementScript.anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            //dialogueScript.endingDialogueBox.SetActive(true);
            dialogueScript.StartDialogue();
            hasTriggered = true;
            playerMovementScript.anim.SetBool("isWalking", false);
            playerMovementScript.anim.SetBool("isWalkingNoKey", false);
            playerMovementScript.anim.SetBool("isIdle", true);
        }
    }
}