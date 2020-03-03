using UnityEngine;
using TMPro;

public class LobbyMirror : MonoBehaviour {
	readonly int[] powersOf2 = new int[] { 0, 16, 32, 64, 128, 256, 512, 1024, 2048};

	[SerializeField] int maxResolution = 2048;
	[SerializeField] int currResolution = 256;

	[SerializeField] ReflectionProbe reflection;
	[SerializeField] TextMeshProUGUI outputField;

	void Awake() {
		SetReflectionResolution(currResolution);
	}

	public void SetReflectionResolution(int res) {
		if (res > maxResolution)
			res = maxResolution;
		if(res == 0) {
			reflection.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.OnAwake;
			reflection.resolution = currResolution = res;
			outputField.text = "Mirror disabled ";
			return;
		}
		else if(reflection.refreshMode == UnityEngine.Rendering.ReflectionProbeRefreshMode.OnAwake)
			reflection.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.EveryFrame;
		reflection.resolution = currResolution = res;
		outputField.text = "Mirror resolution: " + currResolution.ToString();
	}

	public int GetReflectionResolution() => currResolution;

	public void SwitchToNextPowerOf2() {
		for(int i = 0; i < powersOf2.Length - 1; ++i) {
			if(powersOf2[i] == currResolution) {
				SetReflectionResolution(powersOf2[i + 1]);
				return;
			}
		}

		SetReflectionResolution(powersOf2[0]);
	}
}
