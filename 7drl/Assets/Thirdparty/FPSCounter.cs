// Copyright (c) 2016 Unity Technologies. MIT license - license_unity.txt
// #NVJOB FPS counter and graph - simple and fast. MIT license - license_nvjob.txt
// #NVJOB FPS counter and graph - simple and fast V1.2 - https://nvjob.github.io/unity/nvjob-fps-counter-and-graph
// #NVJOB Nicholas Veselov (independent developer) - https://nvjob.github.io

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {
    public Text counterText;
    public int frameUpdate = 60;
    public int highestPossibleFPS = 300;
    public float graphUpdate = 1.0f;
    public Color graphColor = new Color(1, 1, 1, 0.5f);

    int curCount;

    void Update() {
        curCount = StFPS.Counter(frameUpdate, Time.deltaTime);
        counterText.text = "FPS: " + curCount.ToString();
    }
}

public static class StFPS {
    static List<float> fpsBuffer = new List<float>();
    static float fpsB;
    static int fps;

    public static int Counter(int frameUpdate, float deltaTime) {
        int fpsBCount = fpsBuffer.Count;

        if (fpsBCount <= frameUpdate) fpsBuffer.Add(1.0f / Time.deltaTime);
        else {
            for (int f = 0; f < fpsBCount; f++) fpsB += fpsBuffer[f];
            fpsBuffer = new List<float> { 1.0f / Time.deltaTime };
            fpsB = fpsB / fpsBCount;
            fps = Mathf.RoundToInt(fpsB);
            fpsB = 0;
        }

        return fps;
    }
}