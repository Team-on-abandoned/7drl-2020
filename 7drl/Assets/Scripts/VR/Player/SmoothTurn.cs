using UnityEngine;

public class SmoothTurn : ATurnType {

    public override void Init() {

    }

    public override void Unuse() {
        enabled = false;
    }

    public override void Use() {
        enabled = true;
    }
}
