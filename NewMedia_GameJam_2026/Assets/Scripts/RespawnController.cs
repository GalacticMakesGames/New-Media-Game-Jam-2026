using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public static RespawnController Instance;
    public Vector3 lastCheckpointPosition;
    public GameObject player;
    [SerializeField] PlayerMovement playerMovementScript;

    void Awake()
    {
        Instance = this;
        // Set initial respawn position at the start of the game
        lastCheckpointPosition = player.transform.position;
    }

    public void SetNewRespawnPoint(Vector3 newPosition)
    {
        lastCheckpointPosition = newPosition;
        Debug.Log("New Respawn Point Set: " + lastCheckpointPosition);
    }

    public void RespawnPlayer()
    {
        // Teleport the player to the current respawn position
        playerMovementScript.enabled = false; // Disable character controller before teleporting to avoid issues, then re-enable
        player.transform.position = lastCheckpointPosition;
        playerMovementScript.enabled = true;
        Debug.Log("Player Respawned to: " + lastCheckpointPosition);
    }
}
