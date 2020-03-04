﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Collider dangling from the player's head
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem {
	//-------------------------------------------------------------------------
	[RequireComponent(typeof(CapsuleCollider))]
	public class BodyCollider : MonoBehaviour {
		public Transform head;

		[SerializeField] float yOffset = 0.07999986f;
		[SerializeField] CharacterController characterController;
		private CapsuleCollider capsuleCollider;

		//-------------------------------------------------
		void Awake() {
			capsuleCollider = GetComponent<CapsuleCollider>();
		}


		//-------------------------------------------------
		void FixedUpdate() {
			float distanceFromFloor = Vector3.Dot(head.localPosition, Vector3.up) + yOffset;
			capsuleCollider.height = Mathf.Max(capsuleCollider.radius, distanceFromFloor);
			characterController.height = Mathf.Max(characterController.radius, distanceFromFloor);
			transform.localPosition = head.localPosition - 0.5f * distanceFromFloor * Vector3.up;
			characterController.center = transform.localPosition;
		}
	}
}
