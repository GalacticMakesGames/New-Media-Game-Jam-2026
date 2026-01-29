using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipTrigger : MonoBehaviour
{
    public GameObject tooltipUI;
    public GameObject tooltipUIPanel;

    // The text to display when the player enters the collider
    public string tooltipMessage = "Move with A and D";

    private TextMeshProUGUI tooltipTextComponent;

    // Start is called before the first frame update
    void Start()
    {
        if (tooltipUI != null)
        {
            tooltipTextComponent = tooltipUI.GetComponent<TextMeshProUGUI>();
            tooltipUI.SetActive(false);
            tooltipUIPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (tooltipUI != null)
            {
                // Set the text and make the UI visible
                if (tooltipTextComponent != null)
                {
                    tooltipTextComponent.text = tooltipMessage;
                }
                tooltipUI.SetActive(true);
                tooltipUIPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (tooltipUI != null)
            {
                // Hide and destroy the UI
                tooltipUI.SetActive(false);
                tooltipUIPanel.SetActive(false);
                Destroy(tooltipUI);
                Destroy(tooltipUIPanel);
            }
        }
    }
}
