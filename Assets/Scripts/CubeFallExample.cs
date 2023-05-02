// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for cubes test in 'rigidbody' test

using UnityEngine;

public class CubeFallExample : MonoBehaviour
{
    [Header("Kick force")]
    public float force;

    private float elapsedTime;
    
    [Header("Cubes setting")]
    public Rigidbody rb;

    public Transform start;

    public Transform camPos;

    private bool hit;

    public bool useGravity;
    
    private void Update()
    {
        if (Camera.main.transform.position != camPos.position)
        {
            return;
        }

        rb.useGravity = useGravity;
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= 4f && !hit)
        {
            rb.AddForce(transform.up * force, ForceMode.Impulse);
            hit = true;
        }
        
        if (!(elapsedTime >= 7f)) return;
        
        transform.position = start.position;
        transform.up = start.up;
        rb.velocity = new Vector3(0, 0, 0);
        rb.freezeRotation = true;
        rb.freezeRotation = false;
        elapsedTime = 0f;
        hit = false;
    }
}
