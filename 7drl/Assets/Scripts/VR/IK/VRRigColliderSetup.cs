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

		rig.leftHand.vrTarget = player.leftHand.GetComponent<HandPhysics>().handCollider.transform;
		rig.leftHand.trackingPosOffset = newLeftHandOffset;
		rig.rightHand.vrTarget = player.rightHand.GetComponent<HandPhysics>().handCollider.transform;
		rig.rightHand.trackingPosOffset = newRightHandOffset;
	}
}
