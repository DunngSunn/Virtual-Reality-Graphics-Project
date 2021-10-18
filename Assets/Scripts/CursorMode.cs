using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CursorMode : MonoBehaviour
{
    private bool _lockCursor;

    private void OnGUI()
    {
        GUI.Label(new Rect(20f, 20f, 500f, 20f), "Press Q to hide/show cursor");
        GUI.Label(new Rect(20f, 40f, 500f, 20f), "Press ESC to quit");
        GUI.Label(new Rect(20, 60f, 500f, 20f), "Use WASD to move");
        GUI.Label(new Rect(20f, 80f, 500f, 20f), "Press Space to jump");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _lockCursor = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _lockCursor = !_lockCursor;
            Cursor.lockState = _lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
