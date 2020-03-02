using UnityEngine;

public abstract class AMoveType : MonoBehaviour{
    abstract public void Init();
    abstract public void Use();
    abstract public void Unuse();
}
