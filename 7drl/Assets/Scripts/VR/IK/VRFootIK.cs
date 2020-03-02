using UnityEngine;

[RequireComponent(typeof(Animator))]
public class VRFootIK : MonoBehaviour {
	[SerializeField] Vector3 footOffset;

	[Range(0f, 1f)]
	[SerializeField] float leftFootPosWeight;
	[Range(0f, 1f)]
	[SerializeField] float leftFootRotWeight;
	[Range(0f, 1f)]
	[SerializeField] float rightFootPosWeight;
	[Range(0f, 1f)]
	[SerializeField] float rightFootRotWeight;

	Animator animator;

	private void Awake() {
		animator = GetComponent<Animator>();
	}

	private void OnAnimatorIK(int layerIndex) {
		Vector3 rightFootPos = animator.GetIKPosition(AvatarIKGoal.RightFoot);

		bool isHit = Physics.Raycast(rightFootPos + Vector3.up, Vector3.down, out RaycastHit hit);
		if (isHit) {
			animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootPosWeight);
			animator.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + footOffset);

			Quaternion footRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);
			animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootRotWeight);
			animator.SetIKRotation(AvatarIKGoal.RightFoot, footRotation);
		}
		else {
			animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
		}

		Vector3 leftFootPos = animator.GetIKPosition(AvatarIKGoal.LeftFoot);

		isHit = Physics.Raycast(leftFootPos + Vector3.up, Vector3.down, out hit);
		if (isHit) {
			animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootPosWeight);
			animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + footOffset);

			Quaternion footRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);
			animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootRotWeight);
			animator.SetIKRotation(AvatarIKGoal.LeftFoot, footRotation);
		}	
		else {
			animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
		}
	}
}
