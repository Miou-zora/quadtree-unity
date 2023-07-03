using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawFPS : MonoBehaviour
{
    private float timer = 0;
    private float refresh = 0.5f;
    private int FPS = 0;
    private GUIStyle style = new GUIStyle();
    private string text = "FPS: 0";

    void Start()
    {
        style.fontSize = 30;
        style.normal.textColor = Color.black;
        updateFPS();
    }
    void OnGUI()
    {
        updateFPS();
        GUI.Label(new Rect(10, 10, 100, 20), text, style);
    }

    private void updateFPS()
    {
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > timer + refresh)
        {
            timer = timeNow;
            FPS = (int)(1.0f / Time.unscaledDeltaTime);
            text = "FPS: " + FPS;
        }
    }
}
