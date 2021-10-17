using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform playerCam;
        
    [SerializeField, Range(1, 10)] private float mouseSensitivity = 1f;
    
    private float _mouseX;
    private float _mouseY;
    private float _xRotation = 0;

    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 75 * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 75 * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -75f, 75f);

        playerCam.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * _mouseX);
    }
}
