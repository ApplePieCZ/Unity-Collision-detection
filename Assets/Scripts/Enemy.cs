// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for enemy destruction in 'Demo'

using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemies text")]
    public TextMeshProUGUI text;
    
    private bool destroyed = false;
    [Header("All enemy parts")]
    public GameObject[] parts;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Bullet(Clone)" || destroyed) return;
        
        text.text = (int.Parse(text.text) + 1).ToString();
        destroyed = true;
        
        foreach (var part in parts)
        {
            var rb = part.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}
