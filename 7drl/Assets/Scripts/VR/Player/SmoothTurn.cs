using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SmoothTurn : ATurnType {
    [SerializeField] float speed;
    [SerializeField] SteamVR_Action_Vector2 input;

    float rotateVal;

    public override void Init() {

    }

    public override void Unuse() {
        enabled = false;
    }

    public override void Use() {
        enabled = true;
    }

    void Update() {
        if (Mathf.Abs(input.axis.x) > 0.1f) {
            rotateVal = input.axis.x;
        }
        else {
            rotateVal = 0;
        }
    }

    private void FixedUpdate() {
        if (rotateVal != 0)
            transform.Rotate(Vector3.up, speed * rotateVal * Time.deltaTime);
    }
}
