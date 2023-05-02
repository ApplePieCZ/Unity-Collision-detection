// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for free float camera

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Mouse setting")]
    public float sensitivity;
    public float slowSpeed;
    public float normalSpeed;
    public float sprintSpeed;
    float currentSpeed;

    public TextMeshProUGUI textFps;
    
    private Dictionary<int, string> CachedNumberStrings = new();
    private int[] _frameRateSamples;
    private int _cacheNumbersAmount = 300;
    private int _averageFromAmount = 30;
    private int _averageCounter = 0;
    private int _currentAveraged;
    
    private void Awake()
    {
        for (int i = 0; i < _cacheNumbersAmount; i++) {
            CachedNumberStrings[i] = i.ToString();
        }
        _frameRateSamples = new int[_averageFromAmount];
    }
    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Movement();
            Rotation();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        
        var currentFrame = (int)Math.Round(1f / Time.smoothDeltaTime); 
        _frameRateSamples[_averageCounter] = currentFrame;
        
        var average = 0f;

        foreach (var frameRate in _frameRateSamples) {
            average += frameRate;
        }

        _currentAveraged = (int)Math.Round(average / _averageFromAmount);
        _averageCounter = (_averageCounter + 1) % _averageFromAmount;
        
        
        textFps.text = "FPS: ";
                 textFps.text += _currentAveraged < _cacheNumbersAmount && _currentAveraged > 0
                     ? CachedNumberStrings[_currentAveraged]
                     : _currentAveraged < 0
                         ? "< 0"
                         : _currentAveraged > _cacheNumbersAmount
                             ? $"> {_cacheNumbersAmount}"
                             : "-1";
        
    }

    private void Rotation()
    {
        Vector3 mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        transform.Rotate(mouseInput * sensitivity);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }

    private void Movement()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftAlt))
        {
            currentSpeed = slowSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }
        transform.Translate(input * currentSpeed * Time.deltaTime);
    }
    
}
