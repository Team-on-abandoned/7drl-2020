using System;
using UnityEngine;

[Serializable]
public class VRPlayerSettings {
	public enum UsedPlayerMoving : byte { Teleport, LocomotionHeadDirection, LocomotionControllerDirection, LAST };
	public enum UsedPlayerTurn : byte { Snap, Smooth, LAST };

	[Header("Moving")]
	public UsedPlayerMoving usedMoving;
	public AMoveType[] availableMovings;

	[Header("Rotating")]
	public UsedPlayerTurn usedTurn;
	public ATurnType[] availableTurns;

	[Header("Fullbody avatar")]
	public GameObject avatar;

	public void InitSettings() {
		for (int i = 0; i < availableMovings.Length; ++i) 
			availableMovings[i].Init();
		for (int i = 0; i < availableTurns.Length; ++i)
			availableTurns[i].Init();

		for (int i = 0; i < availableMovings.Length; ++i) {
			if (i == (int)usedMoving)
				availableMovings[i].Use();
			else
				availableMovings[i].Unuse();
		}

		for (int i = 0; i < availableTurns.Length; ++i) {
			if (i == (int)usedTurn)
				availableTurns[i].Use();
			else
				availableTurns[i].Unuse();
		}
	}

	public void NextMove() {
		UsedPlayerMoving newMove = usedMoving + 1;
		if (newMove == UsedPlayerMoving.LAST)
			newMove = 0;
		SelectMove(newMove);
	}

	public void NextTurn() {
		UsedPlayerTurn newTurn = usedTurn + 1;
		if (newTurn == UsedPlayerTurn.LAST)
			newTurn = 0;
		SelectTurn(newTurn);
	}

	public void SelectMove(UsedPlayerMoving move) {
		availableMovings[(byte)usedMoving].Unuse();
		availableMovings[(byte)(usedMoving = move)].Use();
	}

	public void SelectTurn(UsedPlayerTurn turn) {
		availableTurns[(byte)usedTurn].Unuse();
		availableTurns[(byte)(usedTurn = turn)].Use();
	}
}
