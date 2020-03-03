using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(VRRig))]
public class VRRigColliderSetup : MonoBehaviour {
	[SerializeField] Player player;

	[SerializeField] Vector3 newLeftHandOffset;
	[SerializeField] Vector3 newRightHandOffset;

	VRRig rig;

	void Start() {
		rig = GetComponent<VRRig>();

		if(player?.leftHand?.mainRenderModel == null) {
			rig.leftHand.vrTarget = player.leftHand.GetComponent<HandPhysics>().handCollider.transform;
			rig.leftHand.trackingPosOffset = newLeftHandOffset;
		}
		else {
			OnLeftHandInit();
		}

		if(player?.rightHand?.mainRenderModel == null) {
			rig.rightHand.vrTarget = player.rightHand.GetComponent<HandPhysics>().handCollider.transform;
			rig.rightHand.trackingPosOffset = newRightHandOffset;
		}
		else {
			OnRightHandInit();
		}

		player.leftHand.OnInitialized += OnLeftHandInit;
		player.rightHand.OnInitialized += OnRightHandInit;
	}

	void OnLeftHandInit() {
		rig.leftHand.vrTarget = player.leftHand.mainRenderModel.GetComponentInChildren<Animator>().GetBoneTransform(HumanBodyBones.LeftHand).transform;
		rig.leftHand.trackingPosOffset = newLeftHandOffset;
	}

	void OnRightHandInit() {
		rig.rightHand.vrTarget = player.rightHand.mainRenderModel.GetComponentInChildren<Animator>().GetBoneTransform(HumanBodyBones.RightHand).transform;
		rig.rightHand.trackingPosOffset = newRightHandOffset;
	}
}
