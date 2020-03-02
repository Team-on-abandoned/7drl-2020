using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public VRPlayer player;

    private void Awake() {
        instance = this;
    }
}
