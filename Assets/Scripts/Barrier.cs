// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for first barrier in 'collision event' test

using System;
using TMPro;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public TextMeshProUGUI text;

    public bool right;

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        
        text.text = "Hit";
        text.color = Color.green;
        if (right)
        {
            other.rigidbody.AddForce(Vector3.right * 10f, ForceMode.Impulse);
        }
        else
        {
            other.rigidbody.AddForce(Vector3.left * 10f, ForceMode.Impulse);
        }

    }
    
    private void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        text.text = "Deflected";
        text.color = Color.red;

    }

    
    
}
