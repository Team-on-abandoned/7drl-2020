using UnityEngine;
using TMPro;

public class VRPlayer : MonoBehaviour
{
    public GameObject playerAvatar;

    public VRPlayerSettings settings;

    void Start() {
        settings.InitSettings();
    }

    #region VRPlayerSettingsForInspector
    public void SelectNextFullbodyAvatar() {
        settings.avatar.SetActive(!settings.avatar.activeSelf);
    }

    public void SelectNextMovingType() {
        settings.NextMove();
    }

    public void SelectNextRotatingType() {
        settings.NextTurn();
    }

    public void SetNextFullbodyAvatarText(TextMeshProUGUI field) {
        field.text = settings.avatar.activeSelf ? "Avatar: show" : "Avatar: hide";
    }

    public void SetMovingTypeText(TextMeshProUGUI field) {
        field.text = settings.usedMoving.ToString();
    }

    public void SetRotatingTypeText(TextMeshProUGUI field) {
        field.text = settings.usedTurn.ToString();
    }
    #endregion
}
