// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for cubes reset in 'Demo'

using UnityEngine;

public class CubeReset : MonoBehaviour
{
    public Material material;
    [Header("All cubes")]
    public GameObject[] cubes;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        foreach (var i in cubes)
        {
            i.GetComponent<MeshRenderer>().material = material;
        }
    }
}
