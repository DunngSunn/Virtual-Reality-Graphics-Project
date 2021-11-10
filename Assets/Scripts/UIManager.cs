using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject infoTerrain;

    private bool _showInfo;
    private bool _showTutorial;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        tutorial.SetActive(true);
        infoTerrain.SetActive(false);
        _showInfo = false;
        _showTutorial = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _showTutorial = !_showTutorial;
            tutorial.SetActive(_showTutorial);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _showInfo = !_showInfo;
            infoTerrain.SetActive(_showInfo);
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
