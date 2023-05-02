// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for camera hand over

using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
