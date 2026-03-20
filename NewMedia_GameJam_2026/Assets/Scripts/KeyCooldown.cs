using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyCooldown
{
    [SerializeField] private float cooldownTime;
    private float nextKeyPlacementTime;

    public bool isCoolingDown => Time.time < nextKeyPlacementTime;
    public void StartCooldown() => nextKeyPlacementTime = Time.time + cooldownTime;
}
