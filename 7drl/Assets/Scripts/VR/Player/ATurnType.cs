using UnityEngine;

public abstract class ATurnType : MonoBehaviour
{
    abstract public void Init();
    abstract public void Use();
    abstract public void Unuse();
}
