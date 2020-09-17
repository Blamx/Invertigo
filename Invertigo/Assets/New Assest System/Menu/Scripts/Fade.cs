﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{


    public Texture2D fadeTex;
    public float fadeSpeed;

    int drawDepth = -1000;
    float alpha = 1.0f;
    int fadeDir = -1;

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),fadeTex);
    }

    public float beginfade(int dir)
    {
        fadeDir = dir;
        return (fadeSpeed);
    }

    private void OnLevelWasLoaded(int level)
    {
        beginfade(-1);
    }
}

