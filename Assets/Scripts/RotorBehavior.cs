// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for rotors rotation in 'collisions' test

using UnityEngine;

public class RotorBehavior : MonoBehaviour
{
    public float degrees;
    private void Update()
    {
        transform.Rotate (0, degrees*Time.deltaTime,0);
    }
}
