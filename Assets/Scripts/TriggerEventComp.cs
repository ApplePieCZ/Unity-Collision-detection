// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for trigger and collision event comparison in 'collision event' test

using UnityEngine;

public class TriggerEventComp : MonoBehaviour
{
    public GameObject[] balls;

    private Vector3 position1;
    private Vector3 position2;

    private float elapsedTime;

    public Transform cameraPos;
    
    private void Start()
    {
        position1 = balls[0].transform.position;
        position2 = balls[1].transform.position;
    }

    private void Update()
    {
        if (cameraPos.position.z != -15f)
        {
            return;
        }

        var rb1 = balls[0].GetComponent<Rigidbody>();
        var rb2 = balls[1].GetComponent<Rigidbody>();
        rb1.isKinematic = false;
        rb2.isKinematic = false;
        elapsedTime += Time.deltaTime;

        if (!(elapsedTime >= 4f)) return;
        
        elapsedTime = 0;
        balls[0].transform.position = position1;
        balls[1].transform.position = position2;

    }
}
