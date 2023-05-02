// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for ball behavior in rigidbody test

using TMPro;
using UnityEngine;

public class MassBallBehavior : MonoBehaviour
{
    public float moveSpeed;

    private float elapsedTime = 5.0f;

    public Rigidbody rb;

    public Transform start;

    public TextMeshProUGUI text;
    
    private void Update()
    {
        if (text.text == "Drag:" && Camera.main.transform.position.z != -5.0)
        {
            return;
        }
        
        elapsedTime += Time.deltaTime;
        if (!(elapsedTime >= 5f)) return;
        
        transform.position = start.position;
        transform.up = start.up;
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(transform.up * moveSpeed, ForceMode.Impulse);
        elapsedTime = 0f;
    }
}
