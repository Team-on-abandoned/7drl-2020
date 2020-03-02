using System;
using UnityEngine;

[Serializable]
public class VRPlayerSettings
{
    public enum UsedPlayerMoving { Teleport, Locomotion };
    public enum UsedPlayerTurn { Snap, Smooth };

    [Header("Moving")]
    public UsedPlayerMoving usedMoving;
    public AMoveType[] availableMovings;

    [Header("Rotating")]
    public UsedPlayerTurn usedTurn;
    public ATurnType[] availableTurns;
}
