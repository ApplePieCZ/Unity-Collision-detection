// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for second ball movement in triggers test

using TMPro;
using UnityEngine;

public class Ball2Movement : MonoBehaviour
{
    
    public float speed;

    public Transform[] positions;

    private bool right = true;

    public TextMeshProUGUI text;

    public Transform camTransform;

    private void OnTriggerEnter(Collider other)
    {
        right = false;
        text.text = "Entered: 1";
        text.color = Color.green;
    }
    

    private void Update()
    {
        // Wait until camera gets into position
        if (camTransform.position.z != -5f)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, right ? positions[1].position : 
                                                 positions[0].position, speed * Time.deltaTime);

        if (transform.position == positions[1].position)
        {
            right = false;
        }
        else if (transform.position == positions[0].position)
        {
            right = true;
            text.text = "Entered: 0";
            text.color = Color.red;
        }
    }
}
