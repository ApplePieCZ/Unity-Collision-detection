// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for first person camera

using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Mouse setting")]
    public float sensX;

    public float sensY;

    public Transform orientation;

    private float xRotation;

    private float yRotation;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        var mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
