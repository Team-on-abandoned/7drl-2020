using UnityEngine;
using Valve.VR.InteractionSystem;

public class TeleportMoving :  AMoveType {
    [SerializeField] Teleport teleport;

    public override void Init() {

    }

    public override void Unuse() {
        enabled = teleport.enabled = false;
    }

    public override void Use() {
        enabled = teleport.enabled = true;
    }
}
