using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
    private int FPS_LIMIT = 60;

    void Awake()
    {
        #if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS_LIMIT;
        #endif
    }
}
