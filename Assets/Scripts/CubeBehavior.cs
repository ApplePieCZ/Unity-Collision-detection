// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for cube color change in 'Demo'

using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public Material material;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<MeshRenderer>().material = material;
        }
    }
}
