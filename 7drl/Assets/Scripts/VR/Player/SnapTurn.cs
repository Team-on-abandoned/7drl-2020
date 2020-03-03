using UnityEngine;

public class SnapTurn : ATurnType {
    [SerializeField] Valve.VR.InteractionSystem.SnapTurn snapTurn;

    public override void Init() {

    }

    public override void Unuse() {
        enabled = snapTurn.enabled = false;
    }

    public override void Use() {
        enabled = snapTurn.enabled = true;
    }
}
