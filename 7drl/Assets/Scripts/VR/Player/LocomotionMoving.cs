using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class LocomotionMoving :  AMoveType {
    const float GRAVITY_FORCE = -9.81f;

    [SerializeField] SteamVR_Action_Vector2 input;
    [SerializeField] float speed;
    [SerializeField] bool isUseHMDRotation;

    [Header("Refs")]
    [SerializeField] CharacterController characterController;

    Vector3 direction;

    public override void Init() {

    }

    public override void Unuse() {
        enabled = false;
    }

    public override void Use() {
        enabled = true;
    }

    void Update() {
        if(input.axis.magnitude > 0.1f) {
            direction = isUseHMDRotation ? Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y)) :
                Player.instance.leftHand.transform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        }
        else {
            direction = Vector3.zero;
        }
    }

    private void FixedUpdate() {
        if(direction != Vector3.zero)
            characterController.Move(speed * Time.unscaledDeltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) + new Vector3(0, GRAVITY_FORCE, 0) * Time.deltaTime);
        else
            characterController.Move(new Vector3(0, GRAVITY_FORCE, 0) * Time.deltaTime);
    }
}

