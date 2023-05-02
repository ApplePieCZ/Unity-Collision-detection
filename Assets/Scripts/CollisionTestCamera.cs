// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for camera movement in 'collision event' test

using UnityEngine;

public class CollisionTestCamera : MonoBehaviour
{   
    [Header("Camera positions")]
    public Transform[] positions;

    public Transform cameraPos;

    private int count;

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetButtonDown("Jump")) return;
        
        count++;
        if (count == 3)
        {
            count = 0;
        }

        cameraPos.position = positions[count].position;
        cameraPos.rotation = positions[count].rotation;
    }
}
