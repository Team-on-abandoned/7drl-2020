using System;
using UnityEngine;

public class VRRig : MonoBehaviour {
	[SerializeField] float turnSmooth;

	[SerializeField] VRMap head;
	[SerializeField] VRMap leftHand;
	[SerializeField] VRMap rightHand;

	[SerializeField] Transform headConstraint;
	[SerializeField] Vector3 headBodyOffset;

	void Start() {
		headBodyOffset = transform.position - headConstraint.position;
	}

	void FixedUpdate() {
		transform.position = headConstraint.position + headBodyOffset;
		transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.unscaledDeltaTime * turnSmooth);

		head.Map();
		leftHand.Map();
		rightHand.Map();
	}
}

[Serializable]
public class VRMap {
	public Transform vrTarget;
	public Transform rigTarget;
	public Vector3 trackingPosOffset;	
	public Vector3 trackingRotOffset;	

	public void Map() {
		rigTarget.position = vrTarget.TransformPoint(trackingPosOffset);
		rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotOffset);
	}
}