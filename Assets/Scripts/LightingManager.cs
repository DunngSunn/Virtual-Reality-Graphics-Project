using System;
using System.Collections;
using System.Collections.Generic;
using sc.terrain.vegetationspawner;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [Header("Light references")]
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    
    [Header("Time")]
    [SerializeField, Range(0, 24)] private float timeOfDay;
    [SerializeField] private int hourPerRealSecond;

    private void Update()
    {
        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime / hourPerRealSecond;
            timeOfDay %= 24;
            UpdateLighting(timeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);

        directionalLight.color = preset.directionalColor.Evaluate(timePercent);
        directionalLight.transform.localRotation = Quaternion.Euler((timePercent * 360f) - 90f, 180f, 0f);
    }
}
