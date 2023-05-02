// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for ball movement in 'collision event test'

using UnityEngine;

public class BallEvent : MonoBehaviour
{
    [Header("Initial kick force")]
    public float force;

    public bool run1;

    private bool kicked = false;
    
    private void Start()
    {
        if (!run1) return;
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * force, ForceMode.Impulse);

    }

    private void Update()
    {
        if (Camera.main.transform.position.z != -65f || kicked) return;
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * force, ForceMode.Impulse);
        kicked = true;
    }
}
