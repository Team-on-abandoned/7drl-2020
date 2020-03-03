using UnityEngine;

public class LocomotionMoving :  AMoveType {

    public override void Init() {

    }

    public override void Unuse() {
        enabled = false;
    }

    public override void Use() {
        enabled = true;
    }
}

