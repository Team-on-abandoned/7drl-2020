using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(VRRig))]
public class VRAnimatorController : MonoBehaviour {
	[SerializeField] float movingThreshold = 0.1f;
	[Range(0, 1)]
	[SerializeField] float smoothnig = 0.255f;

	[Header("Animator variables")]
	[SerializeField] string animatorIsWalking = "IsWalking";
	[SerializeField] string animatorBlendX = "DirectionX";
	[SerializeField] string animatorBlendY = "DirectionY";

	Animator animator;
	VRRig rig;

	Vector3 prevPos;

	private void Awake() {
		animator = GetComponent<Animator>();
		rig = GetComponent<VRRig>();

		prevPos = rig.head.vrTarget.position;
	}

	void Update() {
		Vector3 headsetSpeed = (rig.head.vrTarget.position - prevPos) / Time.unscaledDeltaTime;
		headsetSpeed.y = 0;
		Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
		prevPos = rig.head.vrTarget.position;

		float prevDirX = animator.GetFloat(animatorBlendX);
		float prevDirY = animator.GetFloat(animatorBlendY);

		animator.SetBool(animatorIsWalking, headsetLocalSpeed.magnitude > movingThreshold);
		animator.SetFloat(animatorBlendX, Mathf.Lerp(prevDirX, Mathf.Clamp(headsetLocalSpeed.x, -1.0f, 1.0f), smoothnig * Time.unscaledDeltaTime));
		animator.SetFloat(animatorBlendY, Mathf.Lerp(prevDirY, Mathf.Clamp(headsetLocalSpeed.z, -1.0f, 1.0f), smoothnig * Time.unscaledDeltaTime));
	}
}
